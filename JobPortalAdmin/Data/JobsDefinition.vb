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

Partial Public Class JobsDefinition
    Public Property Id As Integer
    Public Property JobTitle As String
    Public Property JobDescription As String
    Public Property StartPublishDate As Nullable(Of Date)
    Public Property EndPublishDate As Nullable(Of Date)
    Public Property MinDegreeId As Nullable(Of Integer)
    Public Property Major As String
    Public Property MinYearsOfExperance As Nullable(Of Integer)
    Public Property JobRequirement As String
    Public Property IsActive As Boolean

    Public Overridable Property Degree As Degree
    Public Overridable Property JobApplications As ICollection(Of JobApplication) = New HashSet(Of JobApplication)

End Class
