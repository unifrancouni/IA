Imports System.Runtime.InteropServices
Imports Microsoft.Win32.SafeHandles

Public Class DriverWork
#Region "Declarations"
    Public Enum Rules
        ' Process hooks IOCTLs 
        ADD_PROCESS_RULE = &H801
        DELETE_PROCESS_RULE = &H802
        CLEAR_PROCESS_RULE = &H803
        QUERY_PROCESS_RULE = &H804
        ' File hooks IOCTLs 
        ADD_FILE_RULE = &H901
        DELETE_FILE_RULE = &H902
        CLEAR_FILE_RULE = &H903
        QUERY_FILE_RULE = &H904
    End Enum

    '// Define the method codes for how buffers are passed for I/O and FS controls
    Private Const METHOD_BUFFERED = 0
    Private Const METHOD_IN_DIRECT = 1
    Private Const METHOD_OUT_DIRECT = 2
    Private Const METHOD_NEITHER = 3

    '// Define the access check value for any access
    '//
    '// The FILE_READ_ACCESS and FILE_WRITE_ACCESS constants are also defined in
    '// ntioapi.h as FILE_READ_DATA and FILE_WRITE_DATA. The values for these
    '// constants *MUST* always be in sync.
    '//
    '// FILE_SPECIAL_ACCESS is checked by the NT I/O system the same as FILE_ANY_ACCESS.
    '// The file systems, however, may add additional access checks for I/O and FS controls
    '// that use this value.
    Private Const FILE_ANY_ACCESS = 0
    Private Const FILE_SPECIAL_ACCESS = FILE_ANY_ACCESS
    Private Const FILE_READ_ACCESS = &H1     '// file & pipe
    Private Const FILE_WRITE_ACCESS = &H2    '// file & pipe

    Private Enum EFileAccess
        ''  The following are masks for the predefined standard access types
        DELETE = &H10000
        READ_CONTROL = &H20000
        WRITE_DAC = &H40000
        WRITE_OWNER = &H80000
        SYNCHRONIZE = &H100000

        STANDARD_RIGHTS_REQUIRED = &HF0000
        STANDARD_RIGHTS_READ = READ_CONTROL
        STANDARD_RIGHTS_WRITE = READ_CONTROL
        STANDARD_RIGHTS_EXECUTE = READ_CONTROL
        STANDARD_RIGHTS_ALL = &H1F0000
        SPECIFIC_RIGHTS_ALL = &HFFFF

        '' AccessSystemAcl access type
        ACCESS_SYSTEM_SECURITY = &H1000000

        '' MaximumAllowed access type
        MAXIMUM_ALLOWED = &H2000000

        ''  These are the generic rights.
        GENERIC_READ = &H80000000
        GENERIC_WRITE = &H40000000
        GENERIC_EXECUTE = &H20000000
        GENERIC_ALL = &H10000000
    End Enum

    Private Enum EFileShare
        FILE_SHARE_NONE = &H0
        FILE_SHARE_READ = &H1
        FILE_SHARE_WRITE = &H2
        FILE_SHARE_DELETE = &H4
    End Enum

    Private Enum ECreationDisposition
        ' <summary>
        ' Creates a new file, only if it does not already exist.
        ' If the specified file exists, the function fails and the last-error code is set to ERROR_FILE_EXISTS (80).
        ' If the specified file does not exist and is a valid path to a writable location, a new file is created.
        ' </summary>
        CREATE_NEW = 1

        ' <summary>
        ' Creates a new file, always.
        ' If the specified file exists and is writable, the function overwrites the file, the function succeeds, and last-error code is set to ERROR_ALREADY_EXISTS (183).
        ' If the specified file does not exist and is a valid path, a new file is created, the function succeeds, and the last-error code is set to zero.
        ' For more information, see the Remarks section of this topic.
        ' </summary>
        CREATE_ALWAYS = 2

        ' <summary>
        ' Opens a file or device, only if it exists.
        ' If the specified file or device does not exist, the function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2).
        ' For more information about devices, see the Remarks section.
        ' </summary>
        OPEN_EXISTING = 3

        ' <summary>
        ' Opens a file, always.
        ' If the specified file exists, the function succeeds and the last-error code is set to ERROR_ALREADY_EXISTS (183).
        ' If the specified file does not exist and is a valid path to a writable location, the function creates a file and the last-error code is set to zero.
        ' </summary>
        OPEN_ALWAYS = 4

        ' <summary>
        ' Opens a file and truncates it so that its size is zero bytes, only if it exists.
        ' If the specified file does not exist, the function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2).
        ' The calling process must open the file with the GENERIC_WRITE bit set as part of the dwDesiredAccess parameter.
        ' </summary>
        TRUNCATE_EXISTING = 5
    End Enum

    Private Enum EDeviceType As UInteger
        FILE_DEVICE_8042_PORT = &H27
        FILE_DEVICE_ACPI = &H32
        FILE_DEVICE_BATTERY = &H29
        FILE_DEVICE_BEEP = &H1
        FILE_DEVICE_BUS_EXTENDER = &H2A
        FILE_DEVICE_CD_ROM = &H2
        FILE_DEVICE_CD_ROM_FILE_SYSTEM = &H3
        FILE_DEVICE_CHANGER = &H30
        FILE_DEVICE_CONTROLLER = &H4
        FILE_DEVICE_DATALINK = &H5
        FILE_DEVICE_DFS = &H6
        FILE_DEVICE_DFS_FILE_SYSTEM = &H35
        FILE_DEVICE_DFS_VOLUME = &H36
        FILE_DEVICE_DISK = &H7
        FILE_DEVICE_DISK_FILE_SYSTEM = &H8
        FILE_DEVICE_DVD = &H33
        FILE_DEVICE_FILE_SYSTEM = &H9
        FILE_DEVICE_FIPS = &H3A
        FILE_DEVICE_FULLSCREEN_VIDEO = &H34
        FILE_DEVICE_INPORT_PORT = &HA
        FILE_DEVICE_KEYBOARD = &HB
        FILE_DEVICE_KS = &H2F
        FILE_DEVICE_KSEC = &H39
        FILE_DEVICE_MAILSLOT = &HC
        FILE_DEVICE_MASS_STORAGE = &H2D
        FILE_DEVICE_MIDI_IN = &HD
        FILE_DEVICE_MIDI_OUT = &HE
        FILE_DEVICE_MODEM = &H2B
        FILE_DEVICE_MOUSE = &HF
        FILE_DEVICE_MULTI_UNC_PROVIDER = &H10
        FILE_DEVICE_NAMED_PIPE = &H11
        FILE_DEVICE_NETWORK = &H12
        FILE_DEVICE_NETWORK_BROWSER = &H13
        FILE_DEVICE_NETWORK_FILE_SYSTEM = &H14
        FILE_DEVICE_NETWORK_REDIRECTOR = &H28
        FILE_DEVICE_NULL = &H15
        FILE_DEVICE_PARALLEL_PORT = &H16
        FILE_DEVICE_PHYSICAL_NETCARD = &H17
        FILE_DEVICE_PRINTER = &H18
        FILE_DEVICE_SCANNER = &H19
        FILE_DEVICE_SCREEN = &H1C
        FILE_DEVICE_SERENUM = &H37
        FILE_DEVICE_SERIAL_MOUSE_PORT = &H1A
        FILE_DEVICE_SERIAL_PORT = &H1B
        FILE_DEVICE_SMARTCARD = &H31
        FILE_DEVICE_SMB = &H2E
        FILE_DEVICE_SOUND = &H1D
        FILE_DEVICE_STREAMS = &H1E
        FILE_DEVICE_TAPE = &H1F
        FILE_DEVICE_TAPE_FILE_SYSTEM = &H20
        FILE_DEVICE_TERMSRV = &H38
        FILE_DEVICE_TRANSPORT = &H21
        FILE_DEVICE_UNKNOWN = &H22
        FILE_DEVICE_VDM = &H2C
        FILE_DEVICE_VIDEO = &H23
        FILE_DEVICE_VIRTUAL_DISK = &H24
        FILE_DEVICE_WAVE_IN = &H25
        FILE_DEVICE_WAVE_OUT = &H26
    End Enum

    Private Enum EFileAttributes
        FILE_ATTRIBUTE_READONLY = &H1
        FILE_ATTRIBUTE_HIDDEN = &H2
        FILE_ATTRIBUTE_SYSTEM = &H4
        FILE_ATTRIBUTE_DIRECTORY = &H10
        FILE_ATTRIBUTE_ARCHIVE = &H20
        FILE_ATTRIBUTE_DEVICE = &H40
        FILE_ATTRIBUTE_NORMAL = &H80
        FILE_ATTRIBUTE_TEMPORARY = &H100
        FILE_ATTRIBUTE_SPARSE_FILE = &H200
        FILE_ATTRIBUTE_REPARSE_POINT = &H400
        FILE_ATTRIBUTE_COMPRESSED = &H800
        FILE_ATTRIBUTE_OFFLINE = &H1000
        FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = &H2000
        FILE_ATTRIBUTE_ENCRYPTED = &H4000
        FILE_ATTRIBUTE_VIRTUAL = &H10000

        'This parameter can also contain combinations of flags (FILE_FLAG_*)
        FILE_FLAG_BACKUP_SEMANTICS = &H2000000
        FILE_FLAG_DELETE_ON_CLOSE = &H4000000
        FILE_FLAG_NO_BUFFERING = &H20000000
        FILE_FLAG_OPEN_NO_RECALL = &H100000
        FILE_FLAG_OPEN_REPARSE_POINT = &H200000
        FILE_FLAG_OVERLAPPED = &H40000000
        FILE_FLAG_POSIX_SEMANTICS = &H1000000
        FILE_FLAG_RANDOM_ACCESS = &H10000000
        FILE_FLAG_SEQUENTIAL_SCAN = &H8000000
        FILE_FLAG_WRITE_THROUGH = &H80000000
    End Enum

    'NOTE: lpBytesReturned is a pointer to a non-unicode string.
    <DllImport("kernel32.dll", ExactSpelling:=True, SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function DeviceIoControl(ByVal hDevice As SafeFileHandle, _
                                    ByVal dwIoControlCode As IntPtr, _
                                    ByVal lpInBuffer As String, _
                                    ByVal nInBufferSize As IntPtr, _
                                    ByVal lpOutBuffer As String, _
                                    ByVal nOutBufferSize As IntPtr, _
                                    ByRef lpBytesReturned As IntPtr, _
                                    ByVal lpOverlapped As String) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function CreateFile(ByVal lpFileName As String, _
                               ByVal dwDesiredAccess As EFileAccess, _
                               ByVal dwShareMode As EFileShare, _
                               ByVal lpSecurityAttributes As IntPtr, _
                               ByVal dwCreationDisposition As ECreationDisposition, _
                               ByVal dwFlagsAndAttributes As EFileAttributes, _
                               ByVal hTemplateFile As IntPtr) As SafeFileHandle
    End Function
#End Region

    Public Shared Sub AddRule(ByRef hideRule As Rule, ByRef stringRule As String)
        Dim ioctlCode As UInteger = CTL_CODE(EDeviceType.FILE_DEVICE_UNKNOWN, hideRule, METHOD_BUFFERED, FILE_ANY_ACCESS)

        Dim ret_data As String = StrDup(128, " ")
        Dim BytesReturned As String

        DriverWork.Exchange(ioctlCode, _
                            stringRule, stringRule.Length * 2, _
                            ret_data, ret_data.Length, _
                            BytesReturned)

        If Not (BytesReturned = "0") Then
            Throw New Exception(ReadNonUnicode(ret_data))
        End If
    End Sub

    Private Shared Sub Exchange(ByRef dwIoControlCode As UInteger, _
                        ByRef lpInBuffer As String, _
                        ByRef nInBufferSize As IntPtr, _
                        ByRef lpOutBuffer As String, _
                        ByRef nOutBufferSize As IntPtr, _
                        ByRef lpBytesReturned As String)

        Dim handle As Microsoft.Win32.SafeHandles.SafeFileHandle
        handle = CreateFile("\\.\HideDriver", _
                            EFileAccess.GENERIC_READ Or EFileAccess.GENERIC_WRITE, _
                            EFileShare.FILE_SHARE_READ Or EFileShare.FILE_SHARE_WRITE, _
                            Nothing, _
                            ECreationDisposition.OPEN_EXISTING, _
                            EFileAttributes.FILE_ATTRIBUTE_NORMAL, _
                            Nothing)
        If handle.IsInvalid Then Throw New Exception("Can't get handle to driver: " & Marshal.GetLastWin32Error())

        If Not DeviceIoControl(handle, _
                               dwIoControlCode, _
                               lpInBuffer, nInBufferSize, _
                               lpOutBuffer, nOutBufferSize, _
                               lpBytesReturned, _
                               Nothing) Then
            Throw New Exception("Driver communication error: " & Marshal.GetLastWin32Error())
        End If
    End Sub

    'Reads a non-unicode string stored in a unicode string variable
    Private Shared Function ReadNonUnicode(ByRef ANSIString) As String
        Dim rb As Byte()
        Dim i As Integer = 0
        Dim rs As String = vbNullString
        rb = System.Text.Encoding.Unicode.GetBytes(ANSIString)
        Do While rb(i) <> 0
            rs &= Chr(rb(i))
            i += 1
        Loop
        Return rs
    End Function

    'Get IOCTLCode
    Private Shared Function CTL_CODE(ByVal uiDeviceType As UInteger, ByVal uiFunction As UInteger, ByVal uiMethod As UInteger, ByVal uiAccess As UInteger) As UInteger
        CTL_CODE = ((uiDeviceType) << 16) Or ((uiAccess) << 14) Or ((uiFunction) << 2) Or (uiMethod)
    End Function

End Class
