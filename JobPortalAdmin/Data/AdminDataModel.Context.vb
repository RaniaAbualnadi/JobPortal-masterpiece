﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class EmploymentGateEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=EmploymentGateEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property C__MigrationHistory() As DbSet(Of C__MigrationHistory)
    Public Overridable Property AspNetRoles() As DbSet(Of AspNetRole)
    Public Overridable Property AspNetUserClaims() As DbSet(Of AspNetUserClaim)
    Public Overridable Property AspNetUserLogins() As DbSet(Of AspNetUserLogin)
    Public Overridable Property AspNetUsers() As DbSet(Of AspNetUser)
    Public Overridable Property CVEducations() As DbSet(Of CVEducation)
    Public Overridable Property CvJobs() As DbSet(Of CvJob)
    Public Overridable Property CVSkills() As DbSet(Of CVSkill)
    Public Overridable Property Degrees() As DbSet(Of Degree)
    Public Overridable Property EmailNotifications() As DbSet(Of EmailNotification)
    Public Overridable Property Genders() As DbSet(Of Gender)
    Public Overridable Property InterviewTypes() As DbSet(Of InterviewType)
    Public Overridable Property JobApplications() As DbSet(Of JobApplication)
    Public Overridable Property JobsDefinitions() As DbSet(Of JobsDefinition)
    Public Overridable Property Nationalities() As DbSet(Of Nationality)
    Public Overridable Property Profiles() As DbSet(Of Profile)
    Public Overridable Property ScheduledInterviews() As DbSet(Of ScheduledInterview)

End Class
