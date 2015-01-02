Namespace Settings

    <Serializable()> _
    Public Class CommonSettings
        Inherits BusinessBase(Of CommonSettings)
        Implements ICustomXmlSerialized, IIsDirtyEnough

#Region " Business Methods "

        Private _ID As Guid = Guid.NewGuid
        Private _CodeWageGPM As String = ""
        Private _TaxRates As TaxRateList


        ''' <summary>
        ''' Gets or sets a code for wage used in income tax declaration.
        ''' </summary>
        Public Property CodeWageGPM() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeWageGPM
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If _CodeWageGPM <> value.Trim Then
                    _CodeWageGPM = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a list of possible tax rates for different taxes.
        ''' </summary>
        Public ReadOnly Property TaxRates() As TaxRateList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TaxRates
            End Get
        End Property

        Public ReadOnly Property IsDirtyEnough() As Boolean Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return MyBase.IsDirty OrElse _TaxRates.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _TaxRates.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                If _TaxRates Is Nothing Then Return False
                Return MyBase.IsValid AndAlso _TaxRates.IsValid
            End Get
        End Property



        ''' <summary>
        ''' Gets a list of possible tax rates.
        ''' </summary>
        Public Function GetTaxRates(ByVal TaxType As TaxTarifType) As List(Of Double)
            Dim result As New List(Of Double)
            For Each item As TaxRate In _TaxRates
                If item.TaxType = TaxType Then result.Add(item.TaxRate)
            Next
            result.Sort()
            Return result
        End Function

        Public Function GetAllBrokenRules() As String

            Dim result As String = ""

            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString.Trim

            Dim TaxRateListBrokenRules As String = _TaxRates.GetAllBrokenRules.Trim
            If Not String.IsNullOrEmpty(TaxRateListBrokenRules) Then
                If String.IsNullOrEmpty(result.Trim) Then
                    result = TaxRateListBrokenRules
                Else
                    result = result & vbCrLf & TaxRateListBrokenRules
                End If
            End If

            Return result
        End Function

        Public Overrides Function Save() As CommonSettings

            _TaxRates.ForceCheckRules()
            If Not Me.IsValid Then Throw New Exception("Duomenyse yra klaidų: " & GetAllBrokenRules())

            Dim result As CommonSettings = MyBase.Save
            InvalidateCache()
            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("CodeWageGPM", _
                "darbo užmokesčio kodas GPM deklaracijoje"))
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("General.CommonSettings3")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return True
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.CommonSettings3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList() As CommonSettings

            Dim result As CommonSettings = CacheManager.GetItemFromCache(Of CommonSettings)( _
                GetType(CommonSettings), Nothing)

            If result Is Nothing Then

                result = DataPortal.Fetch(Of CommonSettings)(New Criteria())
                CacheManager.AddCacheItem(GetType(CommonSettings), result, Nothing)

            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal TaxType As TaxTarifType, _
            ByVal ShowObsolete As Boolean) As Csla.FilteredBindingList(Of TaxRate)

            Dim FilterToApply(1) As Object
            FilterToApply(0) = ConvertEnumDatabaseCode(TaxType)
            FilterToApply(1) = ConvertDbBoolean(ShowObsolete)

            Dim result As Csla.FilteredBindingList(Of TaxRate) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of TaxRate)) _
                (GetType(CommonSettings), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As CommonSettings = CommonSettings.GetList
                result = New Csla.FilteredBindingList(Of TaxRate)(BaseList.TaxRates, AddressOf TaxRateFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(CommonSettings), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(CommonSettings))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(CommonSettings))
        End Function


        Private Shared Function TaxRateFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing Then Return True

            Dim TaxType As TaxTarifType = ConvertEnumDatabaseCode(Of TaxTarifType) _
                (DirectCast(DirectCast(filterValue, Object())(0), Integer))
            Dim ShowObsolete As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(1), Integer))

            Dim CI As TaxRate = DirectCast(item, TaxRate)

            If Not ShowObsolete AndAlso CI.IsObsolete Then Return False

            If CI.TaxType <> TaxType Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As CommonSettings
            Dim result As New CommonSettings
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            If GetCurrentIdentity.ConnectionType <> AccDataAccessLayer.ConnectionType.Local _
                OrElse AccDataAccessLayer.Security.IsWebServer(GetCurrentIdentity.IsWebServerImpersonation) Then

                Try

                    CustomXmlSerialization.CustomXmlDeSerializeObj( _
                        AccDataAccessLayer.Utilities.AppPath & "\" & SETTINGSFILENAME, Me)

                Catch ex As Exception
                    Throw New Exception("Klaida. Sugadintas nustatymų failas. " & ex.Message, ex)
                End Try

            ElseIf Utilities._GetCommonSettingsLocal Is Nothing Then

                Throw New Exception("Application settings access method is not set. " _
                    & "Use AttachLocalSettingsMethods to initialize methods.")

            ElseIf Utilities._GetCommonSettingsLocal.Invoke Is Nothing OrElse _
                String.IsNullOrEmpty(Utilities._GetCommonSettingsLocal.Invoke.Trim) Then

                If Utilities._SaveCommonSettingsLocal Is Nothing Then Throw New Exception( _
                    "Application settings modify method is not set. " _
                    & "Use AttachLocalSettingsMethods to initialize methods.")

                ' initialize with default values

                Dim XmlString As String

                Try

                    CustomXmlSerialization.CustomXmlDeSerializeObj( _
                        AccDataAccessLayer.Utilities.AppPath & "\" & SETTINGSFILENAME, Me)
                    XmlString = CustomXmlSerialization.CustomXmlSerializeObj(Me.Clone, "CommonSettings").OuterXml

                Catch ex As Exception
                    Throw New Exception("Klaida. Sugadintas nustatymų failas. " & ex.Message, ex)
                End Try

                Utilities._SaveCommonSettingsLocal.Invoke(XmlString)

            Else

                CustomXmlSerialization.CustomXmlDeSerializeObj(Me, Utilities._GetCommonSettingsLocal.Invoke)

            End If

            _TaxRates.FetchTaxesInUse()

            MarkOld()

        End Sub

        Public Shared Function GetSerializedLocalCopy() As String

            Try

                Dim s As New CommonSettings
                CustomXmlSerialization.CustomXmlDeSerializeObj( _
                    AccDataAccessLayer.Utilities.AppPath & "\" & SETTINGSFILENAME, s)
                Return CustomXmlSerialization.CustomXmlSerializeObj(s, "CommonSettings").OuterXml

            Catch ex As Exception
                Throw New Exception("Klaida. Sugadintas nustatymų failas. " & ex.Message, ex)
            End Try

        End Function

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            If GetCurrentIdentity.ConnectionType <> AccDataAccessLayer.ConnectionType.Local _
                OrElse AccDataAccessLayer.Security.IsWebServer(GetCurrentIdentity.IsWebServerImpersonation) Then

                Try

                    CustomXmlSerialization.CustomXmlSerializeObj(AccDataAccessLayer.Utilities.AppPath _
                        & "\" & SETTINGSFILENAME, Me, "CommonSettings")

                Catch ex As Exception
                    Throw New Exception("Klaida. Sugadintas nustatymų failas. " & ex.Message, ex)
                End Try

            Else

                If Utilities._SaveCommonSettingsLocal Is Nothing Then Throw New Exception( _
                    "Application settings modify method is not set. " _
                    & "Use AttachLocalSettingsMethods to initialize methods.")

                Utilities._SaveCommonSettingsLocal(CustomXmlSerialization.CustomXmlSerializeObj( _
                    Me.Clone, "CommonSettings").OuterXml)

            End If

            MarkOld()

        End Sub


        Private Sub DeSerialize(ByVal node As System.Xml.XmlNode) _
            Implements ICustomXmlSerialized.DeSerialize
            _TaxRates = Settings.TaxRateList.NewTaxRateList
            CustomXmlSerialization.SetValues(_TaxRates, _
                CustomXmlSerialization.GetChildNodeForField(node, "_TaxRates"))
            MarkOld()
        End Sub

        Public Function IsSerializedCollection() As Boolean _
            Implements ICustomXmlSerialized.IsSerializedCollection
            Return False
        End Function

        Private Sub Serialize(ByRef node As System.Xml.XmlNode) _
            Implements ICustomXmlSerialized.Serialize
            CustomXmlSerialization.AddChildNode(node, "_CodeWageGPM", _CodeWageGPM)
            CustomXmlSerialization.AddChildNode(node, "_TaxRates", _TaxRates)
            MarkOld()
        End Sub

#End Region

    End Class

End Namespace