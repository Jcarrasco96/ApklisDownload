Imports System.Runtime.InteropServices

Public Module FileIcon

    Declare Function SHGetFileInfo Lib "shell32.dll" Alias "SHGetFileInfoA" (ByVal pszPath As String, ByVal dwFileAttributes As Long, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As Long, ByVal uFlags As Long) As Long
    Declare Function DestroyIcon Lib "user32" Alias "DestroyIcon" (ByVal hIcon As Long) As Long

    Function GetFileIcon(fileName As String) As Icon
        Dim psfi = New SHFILEINFO
        SHGetFileInfo(fileName, 128, psfi, Marshal.SizeOf(psfi), SHGFI_ICON + SHGFI_USEFILEATTRIBUTES)
        Dim fileIcon = Icon.FromHandle(psfi.hIcon).Clone()
        DestroyIcon(psfi.hIcon)
        Return fileIcon
    End Function

    Function GetFileIcon(fileName As String, iconSize As IconSize) As Icon
        Dim psfi = New SHFILEINFO
        SHGetFileInfo(fileName, 128, psfi, Marshal.SizeOf(psfi), iconSize + SHGFI_ICON + SHGFI_USEFILEATTRIBUTES)
        Dim fileIcon = Icon.FromHandle(psfi.hIcon).Clone()
        DestroyIcon(psfi.hIcon)
        Return fileIcon
    End Function

    Function GetFolderIcon(folderName As String) As Icon
        Dim psfi = New SHFILEINFO
        SHGetFileInfo(folderName, 16, psfi, Marshal.SizeOf(psfi), SHGFI_ICON + SHGFI_USEFILEATTRIBUTES)
        Dim fileIcon = Icon.FromHandle(psfi.hIcon).Clone()
        DestroyIcon(psfi.hIcon)
        Return fileIcon
    End Function

    Function GetFolderIcon(folderName As String, iconSize As IconSize) As Icon
        Dim psfi = New SHFILEINFO
        SHGetFileInfo(folderName, 16, psfi, Marshal.SizeOf(psfi), iconSize + SHGFI_ICON + SHGFI_USEFILEATTRIBUTES)
        Dim fileIcon = Icon.FromHandle(psfi.hIcon).Clone()
        DestroyIcon(psfi.hIcon)
        Return fileIcon
    End Function

    Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As UInteger
        Public szDisplayName As String
        Public szTypeName As String
    End Structure

    Enum IconSize
        SHGFI_LARGEICON = &H0   '  get large icon
        SHGFI_SMALLICON = &H1   '  get small icon
        SHGFI_OPENICON = &H2    '  get open icon
    End Enum

    Const SHGFI_ICON = &H100                         '  get icon
    Const SHGFI_DISPLAYNAME = &H200                  '  get display name
    Const SHGFI_TYPENAME = &H400                     '  get type name
    Const SHGFI_ATTRIBUTES = &H800                   '  get attributes
    Const SHGFI_ICONLOCATION = &H1000                '  get icon location
    Const SHGFI_EXETYPE = &H2000                     '  return exe type
    Const SHGFI_SYSICONINDEX = &H4000                '  get system icon index

    Const SHGFI_LINKOVERLAY = &H8000                 '  put a link overlay on icon
    Const SHGFI_SELECTED = &H10000                   '  show icon in selected state

    Const SHGFI_SHELLICONSIZE = &H4                  '  get shell size icon
    Const SHGFI_PIDL = &H8                           '  pszPath is a pidl
    Const SHGFI_USEFILEATTRIBUTES = &H10             '  use passed dwFileAttribute

End Module
