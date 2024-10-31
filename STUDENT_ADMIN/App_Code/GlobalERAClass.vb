Imports System
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.Security
Imports System.Text

Namespace DECV_PROD2007.GlobalERA

Public Class [GlobalERAClass]
	'May-2016|Eric Affleck - eratechnology - created global class to allow global functions to be shared
    
	Public Shared Function CheckUserAccessGroups(byval strAccessGroup as string, ByVal e As System.EventArgs) as boolean
	  ' global ish function to get a string of Function Codes for this User's Group
	  ' Mainly used with ERAFunction_CheckAccessCodes to set visible to true/false
	  ' Renamed from ERAFunction_CheckUserAccessGroups and migrated from Menu.aspx.vb
	  ' checks the strAccessGroup supplied (eg: "L") from the session 'AccessGroups' (eg: "RTVL") 
	  '		and returns true/false if strAccessGroup exists in the AccessGroups
		dim retval as boolean = false

		if (not String.IsNullOrEmpty(strAccessGroup)) then
			dim tmpsessGroup as string = HttpContext.Current.Session("AccessGroups")
			if (instr(tmpsessGroup, strAccessGroup) > 0) then
				retval = true
			else
				retval = false
			end if
		end if
		return retval

	End Function
  
End Class
End Namespace