'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class ScheduledInterview
    Public Property Id As Integer
    Public Property JobApplicationId As Integer
    Public Property InvitationDate As Date
    Public Property InterviewDate As Date
    Public Property IsAttended As Boolean
    Public Property InterviewTypeId As Integer
    Public Property IsPassed As Boolean
    Public Property Score As Nullable(Of Double)
    Public Property ArchivedForLater As Nullable(Of Boolean)
    Public Property InterviewReport As String

    Public Overridable Property InterviewType As InterviewType
    Public Overridable Property JobApplication As JobApplication

End Class