Imports ApskaitaObjects.HelperLists
Namespace Documents

    <Serializable()> _
    Public Class InvoiceMade
        Inherits BusinessBase(Of InvoiceMade)
        Implements IIsDirtyEnough, IClientEmailProvider

#Region " Business Methods "

        Private _ID As Integer = -1
        Private _ChronologyValidator As ComplexChronologicValidator
        Private _Payer As PersonInfo = Nothing
        Private _AccountPayer As Long = 0
        Private _Date As Date = Today
        Private _OldDate As Date = Today
        Private _Serial As String = ""
        Private _Number As Integer = 0
        Private _Content As String = ""
        Private _Type As InvoiceType = InvoiceType.Normal
        Private _DefaultVatRate As Double = 0
        Private WithEvents _InvoiceMadeItems As InvoiceMadeItemList
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _LanguageCode As String = LanguageCodeLith.Trim.ToUpper
        Private _LanguageName As String = GetLanguageName(LanguageCodeLith, False)
        Private _CustomInfo As String = ""
        Private _CustomInfoAltLng As String = ""
        Private _VatExemptInfo As String = ""
        Private _VatExemptInfoAltLng As String = ""
        Private _CommentsInternal As String = ""
        Private _SumLTL As Double = 0
        Private _SumVatLTL As Double = 0
        Private _SumTotalLTL As Double = 0
        Private _Sum As Double = 0
        Private _SumVat As Double = 0
        Private _SumTotal As Double = 0
        Private _SumDiscount As Double = 0
        Private _SumDiscountVat As Double = 0
        Private _SumDiscountLTL As Double = 0
        Private _SumDiscountVatLTL As Double = 0
        Private _ExternalID As String = ""
        Private _FullNumber As String = ""
        Private _AddDateToNumberOptionWasUsed As Boolean = False
        Private _NumbersInInvoice As Integer = 0
        Private _IsDoomyInvoice As Boolean = False
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now

        Private SuspendChildListChangedEvents As Boolean = False


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property ChronologyValidator() As ComplexChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologyValidator
            End Get
        End Property

        Public Property Payer() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Payer
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)
                If Not (_Payer Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Payer Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Payer = value) Then
                    _Payer = value
                    PropertyHasChanged()
                    If Not _Payer Is Nothing AndAlso _Payer.ID > 0 Then
                        LanguageCode = _Payer.LanguageCode
                        If _ChronologyValidator.ParentFinancialDataCanChange Then _
                            AccountPayer = _Payer.AccountAgainstBankBuyer
                        If _ChronologyValidator.FinancialDataCanChange Then _
                            CurrencyCode = _Payer.CurrencyCode
                    End If
                End If
            End Set
        End Property

        Public Property AccountPayer() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPayer
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _AccountPayer <> value AndAlso _ChronologyValidator.ParentFinancialDataCanChange Then
                    _AccountPayer = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                    UpdateFullNumber(True)
                    _InvoiceMadeItems.UpdateDate(_Date)
                End If
            End Set
        End Property

        Public ReadOnly Property OldDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldDate
            End Get
        End Property

        Public Property Serial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Serial.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Serial.Trim.ToUpper <> value.Trim.ToUpper Then
                    _Serial = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Number() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Number
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _Number <> value Then
                    _Number = value
                    PropertyHasChanged()
                    UpdateFullNumber(True)
                End If
            End Set
        End Property

        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property [Type]() As InvoiceType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As InvoiceType)
                CanWriteProperty(True)
                If _Type <> value Then
                    _Type = value
                    PropertyHasChanged()
                    PropertyHasChanged("TypeHumanReadable")
                End If
            End Set
        End Property

        Public Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertEnumHumanReadable(_Type)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If ConvertEnumHumanReadable(Of InvoiceType)(value) <> _Type Then
                    _Type = ConvertEnumHumanReadable(Of InvoiceType)(value)
                    PropertyHasChanged()
                    PropertyHasChanged("Type")
                End If
            End Set
        End Property

        Public ReadOnly Property InvoiceItemsSorted() As SortedBindingList(Of InvoiceMadeItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _SortedList Is Nothing Then _SortedList = _
                    New SortedBindingList(Of InvoiceMadeItem)(_InvoiceMadeItems)
                Return _SortedList
            End Get
        End Property

        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CurrencyCode.Trim <> value.Trim AndAlso _ChronologyValidator.FinancialDataCanChange Then
                    _CurrencyCode = value.Trim
                    PropertyHasChanged()
                    If Not String.IsNullOrEmpty(_CurrencyCode.Trim) AndAlso _
                        _CurrencyCode.Trim.ToUpper <> GetCurrentCompany.BaseCurrency Then
                        CurrencyRate = 0
                    ElseIf Not String.IsNullOrEmpty(_CurrencyCode.Trim) AndAlso _
                        _CurrencyCode.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then
                        CurrencyRate = 1
                    End If
                End If
            End Set
        End Property

        Public Property CurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRate, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_CurrencyRate, 6) <> CRound(value, 6) AndAlso _ChronologyValidator.FinancialDataCanChange Then
                    _CurrencyRate = CRound(value, 6)
                    PropertyHasChanged()
                    If CRound(_CurrencyRate, 6) > 0 Then _InvoiceMadeItems. _
                        UpdateCurrencyRate(_CurrencyRate, _CurrencyCode)
                End If
            End Set
        End Property

        Public Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If value Is Nothing Then value = ""

                If _LanguageCode.Trim.ToUpper <> value.Trim.ToUpper Then
                    _LanguageName = GetLanguageName(value.Trim, False)
                    If String.IsNullOrEmpty(_LanguageName.Trim) Then
                        _LanguageCode = ""
                    Else
                        _LanguageCode = value.Trim.ToUpper
                    End If
                    PropertyHasChanged()
                    PropertyHasChanged("LanguageName")
                    _InvoiceMadeItems.UpdateLanguage(_LanguageCode)
                End If

            End Set
        End Property

        Public Property LanguageName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageName
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If value Is Nothing Then value = ""

                If _LanguageName.Trim.ToUpper <> value.Trim.ToUpper Then
                    _LanguageCode = GetLanguageCode(value.Trim, False)
                    If String.IsNullOrEmpty(_LanguageCode.Trim) Then
                        _LanguageName = ""
                    Else
                        _LanguageName = value.Trim.ToUpper
                    End If
                    PropertyHasChanged()
                    PropertyHasChanged("LanguageCode")
                    _InvoiceMadeItems.UpdateLanguage(_LanguageCode)
                End If

            End Set
        End Property

        Public Property CustomInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CustomInfo.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CustomInfo.Trim <> value.Trim Then
                    _CustomInfo = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CustomInfoAltLng() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CustomInfoAltLng.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CustomInfoAltLng.Trim <> value.Trim Then
                    _CustomInfoAltLng = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property VatExemptInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _VatExemptInfo.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _VatExemptInfo.Trim <> value.Trim Then
                    _VatExemptInfo = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property VatExemptInfoAltLng() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _VatExemptInfoAltLng.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _VatExemptInfoAltLng.Trim <> value.Trim Then
                    _VatExemptInfoAltLng = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CommentsInternal() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CommentsInternal.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CommentsInternal.Trim <> value.Trim Then
                    _CommentsInternal = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        Public ReadOnly Property SumVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVatLTL)
            End Get
        End Property

        Public ReadOnly Property SumTotalLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotalLTL)
            End Get
        End Property

        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        Public ReadOnly Property SumVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVat)
            End Get
        End Property

        Public ReadOnly Property SumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotal)
            End Get
        End Property

        Public ReadOnly Property SumDiscount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscount)
            End Get
        End Property

        Public ReadOnly Property SumDiscountVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscountVat)
            End Get
        End Property

        Public ReadOnly Property SumDiscountLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscountLTL)
            End Get
        End Property

        Public ReadOnly Property SumDiscountVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscountVatLTL)
            End Get
        End Property


        Public ReadOnly Property FullNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FullNumber.Trim
            End Get
        End Property

        Public ReadOnly Property ExternalID() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ExternalID.Trim
            End Get
        End Property

        Public ReadOnly Property AddDateToNumberOptionWasUsed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToNumberOptionWasUsed
            End Get
        End Property

        Public ReadOnly Property NumbersInInvoice() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NumbersInInvoice
            End Get
        End Property

        Public ReadOnly Property DefaultVatRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DefaultVatRate)
            End Get
        End Property

        Public ReadOnly Property IsDoomyInvoice() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsDoomyInvoice
            End Get
        End Property

        Public ReadOnly Property InsertDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        Public ReadOnly Property UpdateDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
        Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (IsNew AndAlso _InvoiceMadeItems.Count > 0) _
                OrElse (Not IsNew AndAlso _InvoiceMadeItems.IsDirty) _
                OrElse (Not String.IsNullOrEmpty(_Content.Trim) _
                OrElse Not String.IsNullOrEmpty(_CustomInfo.Trim) _
                OrElse Not String.IsNullOrEmpty(_CustomInfoAltLng.Trim) _
                OrElse Not String.IsNullOrEmpty(_CommentsInternal.Trim))
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _InvoiceMadeItems.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _InvoiceMadeItems.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error).Trim
            result = AddWithNewLine(result, _InvoiceMadeItems.GetAllBrokenRules, False)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning).Trim
            result = AddWithNewLine(result, _InvoiceMadeItems.GetAllWarnings(), False)


            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Public Overrides Function Save() As InvoiceMade

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Sąskaitos - faktūros duomenyse yra klaidų: " _
                & vbCrLf & Me.GetAllBrokenRules)

            Return MyBase.Save

        End Function


        Public Sub AttachNewObject(ByVal newAttachedObject As InvoiceAttachedObject)

            If newAttachedObject.Type = InvoiceAttachedObjectType.GoodsConsignmentAdditionalCosts Then _
                Throw New Exception("Klaida. Išrašoma sąskaita faktūra neįmanoma padidinti prekių savikainos.")

            _InvoiceMadeItems.Add(InvoiceMadeItem.NewInvoiceMadeItem(newAttachedObject))
            newAttachedObject.FillWithInvoiceDate(_Date)

            _ChronologyValidator.MergeNewValidationItem(newAttachedObject.ChronologyValidator)

        End Sub

        Public Sub AttachNewObject(ByVal nService As ServiceInfo)

            Dim obj As InvoiceAttachedObject = InvoiceAttachedObject.NewInvoiceAttachedObject( _
                nService, _ChronologyValidator.BaseValidator)
            Dim item As InvoiceMadeItem = InvoiceMadeItem.NewInvoiceMadeItem(obj)

            _InvoiceMadeItems.Add(item)

            item.UpdateServiceInfoFinancial(True)
            item.UpdateServiceInfoNames()

            _VatExemptInfo = AddWithNewLine(_VatExemptInfo, DirectCast(obj.ValueObject,  _
                ServiceInfo).RegionalContents.GetRegionalVatExempt(LanguageCodeLith), False)
            _VatExemptInfoAltLng = AddWithNewLine(_VatExemptInfoAltLng, DirectCast(obj.ValueObject,  _
                ServiceInfo).RegionalContents.GetRegionalVatExempt(_LanguageCode), False)

        End Sub


        Public Function GetClientEmail() As String Implements IClientEmailProvider.GetClientEmail
            If _Payer Is Nothing OrElse _Payer.IsEmpty Then Return ""
            Return _Payer.Email
        End Function

        Public Function GetClientName() As String Implements IClientEmailProvider.GetClientName
            If _Payer Is Nothing OrElse _Payer.IsEmpty Then Return ""
            Return _Payer.Name
        End Function


        Private Sub UpdateFullNumber(ByVal RaisePropertyHasChanged As Boolean)

            Dim newNumber As String = ""

            If _AddDateToNumberOptionWasUsed Then
                newNumber = _Date.Year.ToString & GetMinLengthString( _
                    _Date.Month.ToString, 2, "0"c) & GetMinLengthString( _
                    _Date.Day.ToString, 2, "0"c) & "-" & _Number
            Else
                If _NumbersInInvoice < 1 Then
                    newNumber = _Number.ToString
                Else
                    newNumber = GetMinLengthString(_Number.ToString, _NumbersInInvoice, "0"c)
                End If
            End If

            If newNumber.Trim <> _FullNumber.Trim Then
                _FullNumber = newNumber.Trim
                If RaisePropertyHasChanged Then PropertyHasChanged("FullNumber")
            End If

        End Sub


        Private Sub InvoiceMadeItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _InvoiceMadeItems.ListChanged
            If SuspendChildListChangedEvents Then Exit Sub
            CalculateSubTotals(True)
            If e.ListChangedType = ComponentModel.ListChangedType.ItemDeleted OrElse _
                e.ListChangedType = ComponentModel.ListChangedType.Reset Then _
                _ChronologyValidator.ReloadValidationItems(_InvoiceMadeItems.GetChronologyValidators())
        End Sub

        Private Sub CalculateSubTotals(ByVal RaisePropertChangedEvents As Boolean)

            _SumLTL = 0
            _SumVatLTL = 0
            _Sum = 0
            _SumVat = 0
            _SumDiscount = 0
            _SumDiscountVat = 0
            _SumDiscountLTL = 0
            _SumDiscountVatLTL = 0

            For Each i As InvoiceMadeItem In _InvoiceMadeItems
                _SumLTL = CRound(_SumLTL + i.SumLTL - i.DiscountLTL)
                _SumVatLTL = CRound(_SumVatLTL + i.SumVatLTL - i.DiscountVatLTL)
                _Sum = CRound(_Sum + i.Sum - i.Discount)
                _SumVat = CRound(_SumVat + i.SumVat - i.DiscountVat)
                _SumDiscount = CRound(_SumDiscount + i.Discount)
                _SumDiscountVat = CRound(_SumDiscountVat + i.DiscountVat)
                _SumDiscountLTL = CRound(_SumDiscountLTL + i.DiscountLTL)
                _SumDiscountVatLTL = CRound(_SumDiscountVatLTL + i.DiscountVatLTL)
            Next

            _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)
            _SumTotal = CRound(_Sum + _SumVat)

            If RaisePropertChangedEvents Then
                PropertyHasChanged("SumLTL")
                PropertyHasChanged("SumVatLTL")
                PropertyHasChanged("Sum")
                PropertyHasChanged("SumVat")
                PropertyHasChanged("SumDiscount")
                PropertyHasChanged("SumDiscountVat")
                PropertyHasChanged("SumDiscountLTL")
                PropertyHasChanged("SumDiscountVatLTL")
                PropertyHasChanged("SumTotalLTL")
                PropertyHasChanged("SumTotal")
            End If

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As InvoiceMade = DirectCast(MyBase.GetClone(), InvoiceMade)
            result.RestoreChildListsHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildListsHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildListsHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _InvoiceMadeItems.ListChanged, AddressOf InvoiceMadeItems_Changed
            Catch ex As Exception
            End Try
            AddHandler _InvoiceMadeItems.ListChanged, AddressOf InvoiceMadeItems_Changed
        End Sub


        Public Function GetFileName() As String

            Return "Invoice_" & _Date.Year.ToString & "_" _
                & _Date.Month.ToString & "_" & _Date.Day.ToString & "_No_" & _
                _Serial & _FullNumber

        End Function


        Public Function GetInvoiceInfo(ByVal SystemGuid As String) As InvoiceInfo.InvoiceInfo

            Dim result As New InvoiceInfo.InvoiceInfo

            result.AddDateToNumberOptionWasUsed = Me.AddDateToNumberOptionWasUsed
            result.CommentsInternal = Me._CommentsInternal
            result.Content = Me._Content
            result.CurrencyCode = Me._CurrencyCode
            result.CurrencyRate = Me._CurrencyRate
            result.CustomInfo = Me._CustomInfo
            result.CustomInfoAltLng = Me._CustomInfoAltLng
            result.Date = Me._Date
            result.Discount = Me._SumDiscount
            result.DiscountLTL = Me._SumDiscountLTL
            result.DiscountVat = Me._SumDiscountVat
            result.DiscountVatLTL = Me._SumDiscountVatLTL
            result.ExternalID = Me._ExternalID
            result.FullNumber = Me._FullNumber
            result.ID = Me._ID.ToString
            result.LanguageCode = Me._LanguageCode
            result.Number = Me._Number
            result.NumbersInInvoice = Me._NumbersInInvoice
            result.ProjectCode = ""
            result.Serial = Me._Serial
            result.SystemGuid = SystemGuid
            result.Sum = Me._Sum
            result.SumLTL = Me._SumLTL
            result.SumReceived = 0
            result.SumTotal = Me._SumTotal
            result.SumTotalLTL = Me._SumTotalLTL
            result.SumVat = Me._SumVat
            result.SumVatLTL = Me._SumVatLTL
            result.UpdateDate = Me._UpdateDate
            result.VatExemptions = Me._VatExemptInfo
            result.VatExemptionsAltLng = Me._VatExemptInfoAltLng

            If Not _Payer Is Nothing AndAlso _Payer.ID > 0 Then
                result.Payer.Address = _Payer.Address
                result.Payer.BalanceAtBegining = 0
                result.Payer.BreedCode = _Payer.InternalCode
                result.Payer.Code = _Payer.Code
                result.Payer.CodeVAT = _Payer.CodeVAT
                result.Payer.Contacts = _Payer.ContactInfo
                result.Payer.CurrencyCode = _Payer.CurrencyCode
                result.Payer.Email = _Payer.Email
                result.Payer.ExternalID = ""
                result.Payer.ID = _Payer.ID.ToString
                result.Payer.IsClient = _Payer.IsClient
                result.Payer.IsCodeLocal = False
                result.Payer.IsNaturalPerson = _Payer.IsNaturalPerson
                result.Payer.IsObsolete = _Payer.IsObsolete
                result.Payer.IsSupplier = _Payer.IsSupplier
                result.Payer.IsWorker = _Payer.IsWorker
                result.Payer.LanguageCode = _Payer.LanguageCode
                result.Payer.Name = _Payer.Name
                result.Payer.VatExemption = ""
                result.Payer.VatExemptionAltLng = ""
            End If

            result.InvoiceItems = Me._InvoiceMadeItems.GetInvoiceItemInfoList

            Return result

        End Function

        Friend Sub SetExternalID(ByVal newExternalID As String, ByVal RaisePropertyHasChanged As Boolean)
            If newExternalID Is Nothing Then newExternalID = ""
            If newExternalID.Trim <> _ExternalID.Trim Then
                _ExternalID = newExternalID.Trim
                If RaisePropertyHasChanged Then PropertyHasChanged("ExternalID")
            End If
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return _Content
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Content", "turinys"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Serial", "užsakymo serija"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Number", "užsakymo numeris"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New CommonValidation.SimpleRuleArgs("CurrencyCode", ""))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("CurrencyRate", "valiutos kursas"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("LanguageName", "kalba"))
            ValidationRules.AddRule(AddressOf CommonValidation.InfoObjectRequired, _
                New CommonValidation.InfoObjectRequiredRuleArgs("Payer", "klientas", "ID"))
            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "ChronologyValidator"))

            ValidationRules.AddRule(AddressOf SumValidation, "Sum")
            ValidationRules.AddRule(AddressOf SumDiscountValidation, "SumDiscount")
            ValidationRules.AddRule(AddressOf AccountPayerValidation, "AccountPayer")

            ValidationRules.AddDependantProperty("Type", "Sum", False)
            ValidationRules.AddDependantProperty("Type", "SumDiscount", False)
            ValidationRules.AddDependantProperty("Payer", "AccountPayer", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that any items exist.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As InvoiceMade = DirectCast(target, InvoiceMade)

            If Not ValObj._InvoiceMadeItems.Count > 0 Then

                e.Description = "Nenurodyta nė viena sąskaitos eilutė."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf ValObj._Type = InvoiceType.Credit AndAlso Not CRound(ValObj._Sum) < 0 Then

                e.Description = "Kreditinė sąskaita turėtų būti neigiama."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that discount is possible.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumDiscountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As InvoiceMade = DirectCast(target, InvoiceMade)

            If ValObj._Type <> InvoiceType.Normal AndAlso CRound(ValObj._SumDiscount) <> 0 Then

                e.Description = "Nuolaidos negalimos kreditinėse ir debetinėse sąskaitose."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that AccountPayer is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountPayerValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As InvoiceMade = DirectCast(target, InvoiceMade)

            If Not ValObj._Payer Is Nothing AndAlso ValObj._Payer.ID > 0 AndAlso _
                Not ValObj._Payer.AccountAgainstBankBuyer > 0 AndAlso _
                Not ValObj._AccountPayer > 0 Then

                e.Description = "Nenurodyta pirkėjo koresponduojanti sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.InvoiceMade2")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMade2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMade1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMade3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMade3")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _SortedList As SortedBindingList(Of InvoiceMadeItem) = Nothing

        Public Shared Function NewInvoiceMade() As InvoiceMade

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Dim CC As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()

            Return New InvoiceMade(CC.AddDateToInvoiceNumber, CC.NumbersInInvoice, _
                CC.GetDefaultRate(General.DefaultRateType.Vat), CC.DefaultInvoiceMadeContent)

        End Function

        Public Shared Function NewInvoiceMade(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal SystemGuid As String, ByVal UseImportedObjectExternalID As Boolean, _
            ByVal clientList As PersonInfoList, ByRef unknownPerson As InvoiceInfo.ClientInfo) As InvoiceMade

            Dim result As New InvoiceMade(info, SystemGuid, UseImportedObjectExternalID, clientList)

            If result.Payer Is Nothing AndAlso Not info.Payer.Code Is Nothing _
                AndAlso Not String.IsNullOrEmpty(info.Payer.Code.Trim) Then
                unknownPerson = info.Payer
            Else
                unknownPerson = Nothing
            End If

            Return result

        End Function


        Public Shared Function GetInvoiceMade(ByVal nID As Integer) As InvoiceMade
            Return DataPortal.Fetch(Of InvoiceMade)(New Criteria(nID, _
                GetCurrentCompany.Rates.GetRate(General.DefaultRateType.Vat)))
        End Function


        Public Shared Sub DeleteInvoiceMade(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Public Function GetInvoiceMadeCopy() As InvoiceMade

            Dim result As InvoiceMade = Me.Clone
            result._ID = -1
            result._Number = 0
            result._Date = Today
            result._FullNumber = ""
            result._InvoiceMadeItems.MarkAsCopy()
            result._ChronologyValidator = ComplexChronologicValidator. _
                NewComplexChronologicValidator(ConvertEnumHumanReadable(DocumentType.InvoiceMade), _
                SimpleChronologicValidator.NewSimpleChronologicValidator( _
                ConvertEnumHumanReadable(DocumentType.InvoiceMade)), Nothing)
            result.MarkNew()

            result.ValidationRules.CheckRules()

            Return result

        End Function

        Public Shared Function DoomyInvoiceMade() As InvoiceMade

            Dim result As New InvoiceMade

            result._IsDoomyInvoice = True

            result._AddDateToNumberOptionWasUsed = GetCurrentCompany.AddDateToInvoiceNumber
            result._CommentsInternal = "Some comments internal"
            result._Content = "Some content"
            result._CurrencyCode = "USD"
            result._CurrencyRate = 2.34267
            result._CustomInfo = "Some custom info"
            result._CustomInfoAltLng = "Some custom info in alternative language"
            result._Date = Today
            result._LanguageCode = "EN"
            result._Number = 123
            result._Payer = PersonInfo.DoomyPersonInfo
            result._Serial = "ORD"

            If result._AddDateToNumberOptionWasUsed Then
                result._FullNumber = result._Date.Year.ToString & GetMinLengthString( _
                result._Date.Month.ToString, 2, "0"c) & GetMinLengthString( _
                result._Date.Day.ToString, 2, "0"c) & "-" & result._Number.ToString
            Else
                result._FullNumber = result._Number.ToString
                If result._FullNumber.Trim.Length < GetCurrentCompany.NumbersInInvoice Then _
                    result._FullNumber = result._FullNumber.Trim.PadLeft(GetCurrentCompany.NumbersInInvoice, "0"c)
            End If

            result._InvoiceMadeItems = InvoiceMadeItemList.DoomyInvoiceMadeItemList

            result.CalculateSubTotals(False)

            Dim _BaseChronologyValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(ConvertEnumHumanReadable(DocumentType.InvoiceMade))

            result._ChronologyValidator = ComplexChronologicValidator. _
                NewComplexChronologicValidator(ConvertEnumHumanReadable(DocumentType.InvoiceMade), _
                _BaseChronologyValidator, New IChronologicValidator() {})

            Return result

        End Function


        Friend Shared Function GetInvoiceMadeOnServer(ByVal nID As Integer) As InvoiceMade
            Dim result As New InvoiceMade
            result.DataPortal_Fetch(New Criteria(nID, 0))
            Return result
        End Function


        Private Sub New()
            ' require use of factory methods

        End Sub

        Private Sub New(ByVal nAddDateToInvoiceNumber As Boolean, ByVal nNumbersInInvoice As Integer, _
            ByVal nVatRate As Double, ByVal nDefaultInvoiceMadeContent As String)
            Create(nAddDateToInvoiceNumber, nNumbersInInvoice, nVatRate, nDefaultInvoiceMadeContent)
        End Sub

        Private Sub New(ByVal info As InvoiceInfo.InvoiceInfo, ByVal SystemGuid As String, _
            ByVal UseImportedObjectExternalID As Boolean, ByVal clientList As PersonInfoList)
            Create(info, SystemGuid, UseImportedObjectExternalID, clientList)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Private _DefaultVatRate As Double
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property DefaultVatRate() As Double
                Get
                    Return _DefaultVatRate
                End Get
            End Property
            Public Sub New(ByVal nID As Integer, ByVal nDefaultVatRate As Double)
                _ID = nID
                _DefaultVatRate = nDefaultVatRate
            End Sub
            Public Sub New(ByVal nID As Integer)
                _ID = nID
                _DefaultVatRate = 0
            End Sub
        End Class


        Private Sub Create(ByVal nAddDateToInvoiceNumber As Boolean, ByVal nNumbersInInvoice As Integer, _
            ByVal nVatRate As Double, ByVal nDefaultInvoiceMadeContent As String)

            _AddDateToNumberOptionWasUsed = nAddDateToInvoiceNumber
            _NumbersInInvoice = nNumbersInInvoice
            _DefaultVatRate = nVatRate
            _Content = nDefaultInvoiceMadeContent

            Dim _BaseChronologyValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(ConvertEnumHumanReadable(DocumentType.InvoiceMade))
            _ChronologyValidator = ComplexChronologicValidator.NewComplexChronologicValidator( _
                ConvertEnumHumanReadable(DocumentType.InvoiceMade), _BaseChronologyValidator, _
                New IChronologicValidator() {})

            _InvoiceMadeItems = InvoiceMadeItemList.NewInvoiceMadeItemList()

            ValidationRules.CheckRules()

        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka sąskaitos - faktūros duomenims gauti.")

            Dim myComm As New SQLCommand("FetchInvoiceMade")
            myComm.AddParam("?MD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    "Klaida. Sąskaitos, kurios ID='" & criteria.ID & "', duomenys nerasti.)")

                _ID = criteria.ID
                _DefaultVatRate = criteria.DefaultVatRate

                Dim dr As DataRow = myData.Rows(0)

                _Date = CDateSafe(dr.Item(0), Today)
                _OldDate = _Date
                _Serial = CStrSafe(dr.Item(1)).Trim
                _Number = CIntSafe(dr.Item(2), 0)
                _FullNumber = CStrSafe(dr.Item(3)).Trim
                _Content = CStrSafe(dr.Item(4)).Trim
                _CurrencyCode = CStrSafe(dr.Item(5)).Trim
                _CurrencyRate = CDblSafe(dr.Item(6), 6, 0)
                _LanguageCode = CStrSafe(dr.Item(7)).Trim
                _LanguageName = GetLanguageName(_LanguageCode, False)
                _AddDateToNumberOptionWasUsed = ConvertDbBoolean(CIntSafe(dr.Item(8), 0))
                _NumbersInInvoice = CIntSafe(dr.Item(9), 0)
                _CustomInfo = CStrSafe(dr.Item(10)).Trim
                _CustomInfoAltLng = CStrSafe(dr.Item(11)).Trim
                _CommentsInternal = CStrSafe(dr.Item(12)).Trim
                _VatExemptInfo = CStrSafe(dr.Item(13)).Trim
                _VatExemptInfoAltLng = CStrSafe(dr.Item(14)).Trim
                _AccountPayer = CLongSafe(dr.Item(15), 0)
                _Type = ConvertEnumDatabaseCode(Of InvoiceType)(CIntSafe(dr.Item(16), 0))
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(17), DateTime.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(18), DateTime.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _ExternalID = CStrSafe(dr.Item(19)).Trim
                ' _DocumentState = CStrSafe(dr.Item(20))
                _Payer = PersonInfo.GetPersonInfo(dr, 21)

            End Using

            Dim _BaseChronologyValidator As SimpleChronologicValidator = _
                SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _Date, ConvertEnumHumanReadable(DocumentType.InvoiceMade))

            _InvoiceMadeItems = InvoiceMadeItemList.GetInvoiceMadeItemList(_ID, _CurrencyRate, _
                _LanguageCode, _DefaultVatRate, _BaseChronologyValidator)

            CalculateSubTotals(False)
            UpdateFullNumber(False)

            _ChronologyValidator = ComplexChronologicValidator.GetComplexChronologicValidator( _
                _ID, _Date, ConvertEnumHumanReadable(DocumentType.InvoiceMade), _
                _BaseChronologyValidator, _InvoiceMadeItems.GetChronologyValidators())

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal SystemGuid As String, ByVal UseImportedObjectExternalID As Boolean, _
            ByVal clientList As PersonInfoList)

            If info.SystemGuid.Trim = SystemGuid.Trim Then
                info.ID = ""
                info.ExternalID = ""
                info.Number = 0
            End If
            If UseImportedObjectExternalID Then
                Me._ExternalID = info.ExternalID
            Else
                Me._ExternalID = info.ID
            End If

            Me._AddDateToNumberOptionWasUsed = info.AddDateToNumberOptionWasUsed
            Me._CommentsInternal = info.CommentsInternal
            Me._Content = info.Content
            If Not info.ProjectCode Is Nothing AndAlso Not String.IsNullOrEmpty(info.ProjectCode.Trim) Then _
                _Content = _Content & " (projektas - " & info.ProjectCode.Trim & ")"
            Me._CurrencyCode = info.CurrencyCode
            Me._CurrencyRate = info.CurrencyRate
            Me._CustomInfo = info.CustomInfo
            Me._CustomInfoAltLng = info.CustomInfoAltLng
            Me._Date = info.Date
            Me._LanguageCode = info.LanguageCode
            Me._Number = info.Number
            Me._NumbersInInvoice = info.NumbersInInvoice
            Me._Serial = info.Serial
            Me._UpdateDate = info.UpdateDate
            Me._VatExemptInfo = info.VatExemptions
            Me._VatExemptInfoAltLng = info.VatExemptions

            UpdateFullNumber(False)

            If Not info.Payer.Code Is Nothing AndAlso Not String.IsNullOrEmpty(info.Payer.Code.Trim) Then
                Me._Payer = clientList.GetPersonInfo(info.Payer.Code)
                If Not Me._Payer Is Nothing Then Me._AccountPayer = Me._Payer.AccountAgainstBankBuyer
            End If

            _InvoiceMadeItems = InvoiceMadeItemList.NewInvoiceMadeItemList( _
                info, _CurrencyRate, _CurrencyCode, _LanguageCode)

            CalculateSubTotals(False)

            Dim _BaseChronologyValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(ConvertEnumHumanReadable(DocumentType.InvoiceMade))

            _ChronologyValidator = ComplexChronologicValidator.NewComplexChronologicValidator( _
                ConvertEnumHumanReadable(DocumentType.InvoiceMade), _BaseChronologyValidator, _
                New IChronologicValidator() {})

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujos sąskaitos - faktūros duomenims įvesti.")

            _InvoiceMadeItems.CheckRules(_ChronologyValidator.BaseValidator)
            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & GetAllBrokenRules())

            CheckIfExternalIdUnique()

            CheckIfNumberUnique()

            Dim JE As General.JournalEntry = GetJournalEntry()

            DatabaseAccess.TransactionBegin()

            JE = JE.SaveChild()

            _ID = JE.ID

            Dim myComm As New SQLCommand("InsertInvoiceMade")
            AddParamsGeneral(myComm)
            AddParamsFinancial(myComm)

            myComm.Execute()

            _InvoiceMadeItems.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka sąskaitos - faktūros duomenims pakeisti.")

            UpdateFullNumber(False)

            _InvoiceMadeItems.CheckRules(_ChronologyValidator.BaseValidator)
            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & GetAllBrokenRules())

            CheckIfExternalIdUnique()

            CheckIfNumberUnique()

            Dim JE As General.JournalEntry = GetJournalEntry()

            CheckIfUpdateDateChanged()

            Dim myComm As SQLCommand
            If _ChronologyValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateInvoiceMade")
                AddParamsFinancial(myComm)
            Else
                myComm = New SQLCommand("UpdateInvoiceMadeGeneral")
            End If
            AddParamsGeneral(myComm)

            DatabaseAccess.TransactionBegin()

            JE = JE.SaveChild()

            myComm.Execute()

            _InvoiceMadeItems.Update(Me)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Private Sub AddParamsGeneral(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _ID)
            myComm.AddParam("?AB", _Serial.Trim)
            myComm.AddParam("?AC", _Number)
            myComm.AddParam("?AF", _LanguageCode.Trim)
            myComm.AddParam("?AG", _VatExemptInfo.Trim)
            myComm.AddParam("?AH", _VatExemptInfoAltLng.Trim)
            myComm.AddParam("?AI", _CustomInfo.Trim)
            myComm.AddParam("?AJ", _CustomInfoAltLng.Trim)
            myComm.AddParam("?AK", _CommentsInternal.Trim)
            myComm.AddParam("?AL", ConvertDbBoolean(_AddDateToNumberOptionWasUsed))
            myComm.AddParam("?AM", _NumbersInInvoice)
            myComm.AddParam("?AO", ConvertEnumDatabaseCode(_Type))
            myComm.AddParam("?AQ", _ExternalID.Trim)
            myComm.AddParam("?AR", "") ' DocumentState

            _UpdateDate = DateTime.Now
            _UpdateDate = New DateTime(Convert.ToInt64(Math.Floor(_UpdateDate.Ticks / TimeSpan.TicksPerSecond) _
                * TimeSpan.TicksPerSecond))
            If Me.IsNew Then _InsertDate = _UpdateDate
            myComm.AddParam("?AP", _UpdateDate.ToUniversalTime)

        End Sub

        Private Sub AddParamsFinancial(ByRef myComm As SQLCommand)

            myComm.AddParam("?AD", _CurrencyCode.Trim)
            myComm.AddParam("?AE", CRound(_CurrencyRate, 5))
            myComm.AddParam("?AN", _AccountPayer)

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka sąskaitos - faktūros duomenims pašalinti.")

            Dim cInvoice As New InvoiceMade
            cInvoice.DataPortal_Fetch(DirectCast(criteria, Criteria))

            For Each item As InvoiceMadeItem In cInvoice._InvoiceMadeItems
                item.CheckIfCanDelete(cInvoice._ChronologyValidator.BaseValidator)
            Next

            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(DirectCast(criteria, Criteria).ID, _
                DocumentType.InvoiceMade)

            Dim myComm As New SQLCommand("DeleteInvoiceMade")
            myComm.AddParam("?MD", DirectCast(criteria, Criteria).ID)

            DatabaseAccess.TransactionBegin()

            General.JournalEntry.DeleteJournalEntryChild(DirectCast(criteria, Criteria).ID)

            myComm.Execute()

            For Each item As InvoiceMadeItem In cInvoice._InvoiceMadeItems
                item.DeleteSelf()
            Next

            DatabaseAccess.TransactionCommit()

        End Sub


        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.InvoiceMade)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.InvoiceMade)
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _Serial & _FullNumber
            result.Person = _Payer

            If IsNew OrElse _ChronologyValidator.FinancialDataCanChange Then

                Dim FullBookEntryList As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)

                For Each i As InvoiceMadeItem In _InvoiceMadeItems
                    FullBookEntryList.AddRange(i.GetBookEntryInternalList(_AccountPayer))
                Next

                FullBookEntryList.Aggregate()

                result.DebetList.Clear()
                result.CreditList.Clear()

                result.DebetList.LoadBookEntryListFromInternalList(FullBookEntryList, False, False)
                result.CreditList.LoadBookEntryListFromInternalList(FullBookEntryList, False, False)

            End If

            If Not result.IsValid Then Throw New Exception("Klaida. Nepavyko generuoti " _
                & "bendrojo žurnalo įrašo: " & result.ToString & vbCrLf & result.GetAllBrokenRules)

            Return result

        End Function

        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfInvoiceMadeUpdateDateChanged")
            myComm.AddParam("?SD", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 Then
                    Throw New Exception("Klaida. Objektas, kurio ID=" & _ID.ToString & ", nerastas.")
                ElseIf DateTime.SpecifyKind(CDateTimeSafe(myData.Rows(0).Item(0), DateTime.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime <> _UpdateDate Then
                    Throw New Exception("Klaida. Objekto paskutinio taisymo data pasikeitė. " _
                        & "Teigtina, kad kitas vartotojas pakeitė dokumentą.")
                End If
            End Using

        End Sub

        Private Sub CheckIfExternalIdUnique()

            If _ExternalID Is Nothing OrElse String.IsNullOrEmpty(_ExternalID.Trim) Then Exit Sub

            Dim myComm As New SQLCommand("FetchInvoiceMadeIdByExternalID")
            myComm.AddParam("?ND", _ID)
            myComm.AddParam("?ED", _ExternalID.Trim)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                    Throw New Exception("Klaida. Išorinis ID='" & _ExternalID.Trim _
                        & "' jau egzistuoja duomenų bazėje.")
            End Using

        End Sub

        Private Sub CheckIfNumberUnique()

            Dim myComm As SQLCommand
            If _AddDateToNumberOptionWasUsed Then
                myComm = New SQLCommand("CheckIfInvoiceNumberUniqueWithDate")
                myComm.AddParam("?ND", _Date)
            Else
                myComm = New SQLCommand("CheckIfInvoiceNumberUnique")
            End If
            myComm.AddParam("?SR", _Serial.Trim.ToUpper)
            myComm.AddParam("?NM", _Number)
            myComm.AddParam("?IN", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 Then Throw New Exception( _
                    "Klaida. Sąskaita - faktūra su tokia serija ir numeriu jau yra.")
            End Using

        End Sub

#End Region

    End Class

End Namespace