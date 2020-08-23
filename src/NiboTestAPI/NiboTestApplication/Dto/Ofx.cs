using System;
using System.Collections.Generic;
using System.Text;

namespace NiboTestApplication.Dto
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DtoData
    {

        private byte oFXHEADERField;

        private string dATAField;

        private byte vERSIONField;

        private string sECURITYField;

        private string eNCODINGField;

        private ushort cHARSETField;

        private string cOMPRESSIONField;

        private string oLDFILEUIDField;

        private string nEWFILEUIDField;

        private DtoDataOFX oFXField;

        /// <remarks/>
        public byte OFXHEADER
        {
            get
            {
                return this.oFXHEADERField;
            }
            set
            {
                this.oFXHEADERField = value;
            }
        }

        /// <remarks/>
        public string DATA
        {
            get
            {
                return this.dATAField;
            }
            set
            {
                this.dATAField = value;
            }
        }

        /// <remarks/>
        public byte VERSION
        {
            get
            {
                return this.vERSIONField;
            }
            set
            {
                this.vERSIONField = value;
            }
        }

        /// <remarks/>
        public string SECURITY
        {
            get
            {
                return this.sECURITYField;
            }
            set
            {
                this.sECURITYField = value;
            }
        }

        /// <remarks/>
        public string ENCODING
        {
            get
            {
                return this.eNCODINGField;
            }
            set
            {
                this.eNCODINGField = value;
            }
        }

        /// <remarks/>
        public ushort CHARSET
        {
            get
            {
                return this.cHARSETField;
            }
            set
            {
                this.cHARSETField = value;
            }
        }

        /// <remarks/>
        public string COMPRESSION
        {
            get
            {
                return this.cOMPRESSIONField;
            }
            set
            {
                this.cOMPRESSIONField = value;
            }
        }

        /// <remarks/>
        public string OLDFILEUID
        {
            get
            {
                return this.oLDFILEUIDField;
            }
            set
            {
                this.oLDFILEUIDField = value;
            }
        }

        /// <remarks/>
        public string NEWFILEUID
        {
            get
            {
                return this.nEWFILEUIDField;
            }
            set
            {
                this.nEWFILEUIDField = value;
            }
        }

        /// <remarks/>
        public DtoDataOFX OFX
        {
            get
            {
                return this.oFXField;
            }
            set
            {
                this.oFXField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFX
    {

        private DtoDataOFXSIGNONMSGSRSV1 sIGNONMSGSRSV1Field;

        private DtoDataOFXBANKMSGSRSV1 bANKMSGSRSV1Field;

        /// <remarks/>
        public DtoDataOFXSIGNONMSGSRSV1 SIGNONMSGSRSV1
        {
            get
            {
                return this.sIGNONMSGSRSV1Field;
            }
            set
            {
                this.sIGNONMSGSRSV1Field = value;
            }
        }

        /// <remarks/>
        public DtoDataOFXBANKMSGSRSV1 BANKMSGSRSV1
        {
            get
            {
                return this.bANKMSGSRSV1Field;
            }
            set
            {
                this.bANKMSGSRSV1Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXSIGNONMSGSRSV1
    {

        private DtoDataOFXSIGNONMSGSRSV1SONRS sONRSField;

        /// <remarks/>
        public DtoDataOFXSIGNONMSGSRSV1SONRS SONRS
        {
            get
            {
                return this.sONRSField;
            }
            set
            {
                this.sONRSField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXSIGNONMSGSRSV1SONRS
    {

        private DtoDataOFXSIGNONMSGSRSV1SONRSSTATUS sTATUSField;

        private string dTSERVERField;

        private string lANGUAGEField;

        /// <remarks/>
        public DtoDataOFXSIGNONMSGSRSV1SONRSSTATUS STATUS
        {
            get
            {
                return this.sTATUSField;
            }
            set
            {
                this.sTATUSField = value;
            }
        }

        /// <remarks/>
        public string DTSERVER
        {
            get
            {
                return this.dTSERVERField;
            }
            set
            {
                this.dTSERVERField = value;
            }
        }

        /// <remarks/>
        public string LANGUAGE
        {
            get
            {
                return this.lANGUAGEField;
            }
            set
            {
                this.lANGUAGEField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXSIGNONMSGSRSV1SONRSSTATUS
    {

        private byte cODEField;

        private string sEVERITYField;

        /// <remarks/>
        public byte CODE
        {
            get
            {
                return this.cODEField;
            }
            set
            {
                this.cODEField = value;
            }
        }

        /// <remarks/>
        public string SEVERITY
        {
            get
            {
                return this.sEVERITYField;
            }
            set
            {
                this.sEVERITYField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXBANKMSGSRSV1
    {

        private DtoDataOFXBANKMSGSRSV1STMTTRNRS sTMTTRNRSField;

        /// <remarks/>
        public DtoDataOFXBANKMSGSRSV1STMTTRNRS STMTTRNRS
        {
            get
            {
                return this.sTMTTRNRSField;
            }
            set
            {
                this.sTMTTRNRSField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXBANKMSGSRSV1STMTTRNRS
    {

        private ushort tRNUIDField;

        private DtoDataOFXBANKMSGSRSV1STMTTRNRSSTATUS sTATUSField;

        private DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRS sTMTRSField;

        /// <remarks/>
        public ushort TRNUID
        {
            get
            {
                return this.tRNUIDField;
            }
            set
            {
                this.tRNUIDField = value;
            }
        }

        /// <remarks/>
        public DtoDataOFXBANKMSGSRSV1STMTTRNRSSTATUS STATUS
        {
            get
            {
                return this.sTATUSField;
            }
            set
            {
                this.sTATUSField = value;
            }
        }

        /// <remarks/>
        public DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRS STMTRS
        {
            get
            {
                return this.sTMTRSField;
            }
            set
            {
                this.sTMTRSField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXBANKMSGSRSV1STMTTRNRSSTATUS
    {

        private byte cODEField;

        private string sEVERITYField;

        /// <remarks/>
        public byte CODE
        {
            get
            {
                return this.cODEField;
            }
            set
            {
                this.cODEField = value;
            }
        }

        /// <remarks/>
        public string SEVERITY
        {
            get
            {
                return this.sEVERITYField;
            }
            set
            {
                this.sEVERITYField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRS
    {

        private string cURDEFField;

        private DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKACCTFROM bANKACCTFROMField;

        private DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLIST bANKTRANLISTField;

        private DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSLEDGERBAL lEDGERBALField;

        /// <remarks/>
        public string CURDEF
        {
            get
            {
                return this.cURDEFField;
            }
            set
            {
                this.cURDEFField = value;
            }
        }

        /// <remarks/>
        public DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKACCTFROM BANKACCTFROM
        {
            get
            {
                return this.bANKACCTFROMField;
            }
            set
            {
                this.bANKACCTFROMField = value;
            }
        }

        /// <remarks/>
        public DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLIST BANKTRANLIST
        {
            get
            {
                return this.bANKTRANLISTField;
            }
            set
            {
                this.bANKTRANLISTField = value;
            }
        }

        /// <remarks/>
        public DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSLEDGERBAL LEDGERBAL
        {
            get
            {
                return this.lEDGERBALField;
            }
            set
            {
                this.lEDGERBALField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKACCTFROM
    {

        private ushort bANKIDField;

        private ulong aCCTIDField;

        private string aCCTTYPEField;

        /// <remarks/>
        public ushort BANKID
        {
            get
            {
                return this.bANKIDField;
            }
            set
            {
                this.bANKIDField = value;
            }
        }

        /// <remarks/>
        public ulong ACCTID
        {
            get
            {
                return this.aCCTIDField;
            }
            set
            {
                this.aCCTIDField = value;
            }
        }

        /// <remarks/>
        public string ACCTTYPE
        {
            get
            {
                return this.aCCTTYPEField;
            }
            set
            {
                this.aCCTTYPEField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLIST
    {

        private string dTSTARTField;

        private string dTENDField;

        private DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN[] sTMTTRNField;

        /// <remarks/>
        public string DTSTART
        {
            get
            {
                return this.dTSTARTField;
            }
            set
            {
                this.dTSTARTField = value;
            }
        }

        /// <remarks/>
        public string DTEND
        {
            get
            {
                return this.dTENDField;
            }
            set
            {
                this.dTENDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("STMTTRN")]
        public DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN[] STMTTRN
        {
            get
            {
                return this.sTMTTRNField;
            }
            set
            {
                this.sTMTTRNField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSBANKTRANLISTSTMTTRN
    {

        private string tRNTYPEField;

        private string dTPOSTEDField;

        private decimal tRNAMTField;

        private string mEMOField;

        /// <remarks/>
        public string TRNTYPE
        {
            get
            {
                return this.tRNTYPEField;
            }
            set
            {
                this.tRNTYPEField = value;
            }
        }

        /// <remarks/>
        public string DTPOSTED
        {
            get
            {
                return this.dTPOSTEDField;
            }
            set
            {
                this.dTPOSTEDField = value;
            }
        }

        /// <remarks/>
        public decimal TRNAMT
        {
            get
            {
                return this.tRNAMTField;
            }
            set
            {
                this.tRNAMTField = value;
            }
        }

        /// <remarks/>
        public string MEMO
        {
            get
            {
                return this.mEMOField;
            }
            set
            {
                this.mEMOField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DtoDataOFXBANKMSGSRSV1STMTTRNRSSTMTRSLEDGERBAL
    {

        private decimal bALAMTField;

        private string dTASOFField;

        /// <remarks/>
        public decimal BALAMT
        {
            get
            {
                return this.bALAMTField;
            }
            set
            {
                this.bALAMTField = value;
            }
        }

        /// <remarks/>
        public string DTASOF
        {
            get
            {
                return this.dTASOFField;
            }
            set
            {
                this.dTASOFField = value;
            }
        }
    }


}