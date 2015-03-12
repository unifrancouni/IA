
opc=0
while opc<1 or opc>2
	opc = inputbox("1: Bloquear" & chr(13)+chr(10) & "2: Desbloquear")
	for i=1 to len(opc)
		if asc(Mid(opc,i,1))<>49 and asc(Mid(opc,i,1))<>50 then
			msgbox "La entrada debe un número entero entre 1 y 2.",vbExclamation
			Wscript.quit(0)
		end if
	next
wend


set obj = CreateObject("WScript.Shell")


if opc=1 then
	obj.run "cmd /C QuitarExt_TXT.bat",0,FALSE
	msgbox "Bloqueado!",vbInformation,"Éxito!"
elseif opc=2 then
	obj.run "cmd /C RegresarExt_TXT.bat",0,FALSE
	msgbox "Desbloqueado!",vbInformation,"Éxito!"
end if