'RC4 Encryption @0-4B437551
'Target Framework version is 3.5
Imports System 
Imports System.Globalization

Public Class RC4
   
   Public Shared Function GetRC4(pStrMessage() As Byte, key As String) As Byte()
        Dim lBytAsciiAry(255) As Byte
        Dim lBytKeyAry(255) As Byte
      Dim lLngIndex As Integer
      
      ' Validate data
      If key.Length = 0 Then
         Return Nothing
      End If
      If pStrMessage.Length = 0 Then
         Return Nothing
      End If 
      ' transfer repeated key to array
      Dim lLngKeyLength As Integer = key.Length
      For lLngIndex = 0 To 255
         lBytKeyAry(lLngIndex) = System.Text.Encoding.ASCII.GetBytes(key.Substring(lLngIndex Mod lLngKeyLength, 1))(0)
      Next lLngIndex 
      ' Initialize S
      For lLngIndex = 0 To 255
         lBytAsciiAry(lLngIndex) = CByte(lLngIndex)
      Next lLngIndex 
      ' Switch values of S arround based off of index and Key value
      Dim lBytJump As Byte = 0
      Dim lBytTemp As Byte
      For lLngIndex = 0 To 255
         ' Figure index to switch
            lBytJump = Convert.ToByte(((lBytJump + CInt(lBytAsciiAry(lLngIndex)) + lBytKeyAry(lLngIndex)) Mod 256))
         
         ' Do the switch
         lBytTemp = lBytAsciiAry(lLngIndex)
         lBytAsciiAry(lLngIndex) = lBytAsciiAry(lBytJump)
         lBytAsciiAry(lBytJump) = lBytTemp
      Next lLngIndex
      
      lLngIndex = 0
      lBytJump = 0
        Dim result(pStrMessage.Length - 1) As Byte
      Dim lLngX As Byte
      For lLngX = 0 To pStrMessage.Length - 1
         lLngIndex = Convert.ToByte(((lLngIndex + 1) Mod 256)) ' wrap index;
            lBytJump = Convert.ToByte(((lBytJump + CInt(lBytAsciiAry(lLngIndex))) Mod 256)) ' wrap J+S();
         ' Add/Wrap those two	    
            Dim lLngT As Byte = Convert.ToByte(((lBytAsciiAry(lLngIndex) + CInt(lBytAsciiAry(lBytJump))) Mod 256))
         ' Switcheroo
         lBytTemp = lBytAsciiAry(lLngIndex)
         lBytAsciiAry(lLngIndex) = lBytAsciiAry(lBytJump)
         lBytAsciiAry(lBytJump) = lBytTemp
         
         Dim lBytY As Byte = lBytAsciiAry(lLngT)
         ' Character Encryption ...    
            result(lLngX) = Convert.ToByte((pStrMessage(lLngX) Xor lBytY))
      Next lLngX
      Return result
   End Function 'GetRC4
   
   
   Overloads Public Shared Function to_hex(n As Integer) As String
      If n < 16 Then
         Return "0" + [String].Format("{0:X}", n)
      Else
         Return [String].Format("{0:X}", n)
      End If
   End Function 'to_hex
    
   Overloads Public Shared Function to_hex(n As String) As String
      Dim result As String = ""
      Dim i As Integer
      For i = 0 To n.Length - 1
         result += to_hex(System.Text.Encoding.ASCII.GetBytes(n.Substring(i, 1))(0))
      Next i
      Return result
   End Function 'to_hex
   
   
   Overloads Public Shared Function to_hex(n() As Byte) As String
      Dim result As String = ""
      Dim i As Integer
      For i = 0 To n.Length - 1
         Dim val As String = [String].Format("{0:X}", n(i))
         If val.Length = 1 Then
            val = "0" + val
         End If
         result += val
      Next i
      Return result
   End Function 'to_hex
   
   
   Public Shared Function from_hex(n As String) As Byte()
      Dim size As Integer = n.Length / 2 + n.Length Mod 2
        Dim result(size - 1) As Byte
      Dim i As Integer
      For i = 0 To n.Length - 2 Step 2
         result(i / 2) = Byte.Parse(n.Chars(i) & "0", NumberStyles.HexNumber)
            If i + 1 < n.Length Then
                result((i / 2)) += Byte.Parse(n.Chars(i + 1) & "", NumberStyles.HexNumber)
            End If
        Next i
        Return result
   End Function 'from_hex
   
   
   Public Shared Function EncodeString(pStrMessage As String, key As String) As String
      Dim result As String = to_hex(GetRC4(System.Text.Encoding.ASCII.GetBytes(pStrMessage), key))
      Return result
   End Function 'RC4encode
   
   
   Public Shared Function DecodeString(pStrMessage As String, key As String) As String
      
      Return System.Text.Encoding.ASCII.GetString(GetRC4(from_hex(pStrMessage), key))
   End Function 
End Class

'End RC4 Encryption

