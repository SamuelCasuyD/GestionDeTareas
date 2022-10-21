/*
				   File: type_SdtGestionTareas_SDT
			Description: GestionTareas_SDT
				 Author: Nemo 🐠 for C# version 16.0.10.142546
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="GestionTareas_SDT")]
	[XmlType(TypeName="GestionTareas_SDT" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtGestionTareas_SDT : GxUserType
	{
		public SdtGestionTareas_SDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtGestionTareas_SDT_Trgestiontareas_nombre = "";

			gxTv_SdtGestionTareas_SDT_Trgestiontareas_descripcion = "";

		}

		public SdtGestionTareas_SDT(IGxContext context)
		{
			this.context = context;
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override String JsonMap(String value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (String)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("TrGestionTareas_ID", gxTpr_Trgestiontareas_id, false);


			AddObjectProperty("TrGestionTareas_IDTablero", gxTpr_Trgestiontareas_idtablero, false);


			AddObjectProperty("TrGestionTareas_Nombre", gxTpr_Trgestiontareas_nombre, false);


			AddObjectProperty("TrGestionTareas_Descripcion", gxTpr_Trgestiontareas_descripcion, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trgestiontareas_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trgestiontareas_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trgestiontareas_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrGestionTareas_FechaInicio", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trgestiontareas_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trgestiontareas_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trgestiontareas_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrGestionTareas_FechaFin", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trgestiontareas_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trgestiontareas_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trgestiontareas_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrGestionTareas_FechaCreacion", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trgestiontareas_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trgestiontareas_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trgestiontareas_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrGestionTareas_FechaModificacion", sDateCnv, false);


			AddObjectProperty("TrGestionTareas_Estado", gxTpr_Trgestiontareas_estado, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TrGestionTareas_ID")]
		[XmlElement(ElementName="TrGestionTareas_ID")]
		public long gxTpr_Trgestiontareas_id
		{
			get { 
				return gxTv_SdtGestionTareas_SDT_Trgestiontareas_id; 
			}
			set { 
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_id = value;
				SetDirty("Trgestiontareas_id");
			}
		}




		[SoapElement(ElementName="TrGestionTareas_IDTablero")]
		[XmlElement(ElementName="TrGestionTareas_IDTablero")]
		public Guid gxTpr_Trgestiontareas_idtablero
		{
			get { 
				return gxTv_SdtGestionTareas_SDT_Trgestiontareas_idtablero; 
			}
			set { 
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_idtablero = value;
				SetDirty("Trgestiontareas_idtablero");
			}
		}




		[SoapElement(ElementName="TrGestionTareas_Nombre")]
		[XmlElement(ElementName="TrGestionTareas_Nombre")]
		public String gxTpr_Trgestiontareas_nombre
		{
			get { 
				return gxTv_SdtGestionTareas_SDT_Trgestiontareas_nombre; 
			}
			set { 
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_nombre = value;
				SetDirty("Trgestiontareas_nombre");
			}
		}




		[SoapElement(ElementName="TrGestionTareas_Descripcion")]
		[XmlElement(ElementName="TrGestionTareas_Descripcion")]
		public String gxTpr_Trgestiontareas_descripcion
		{
			get { 
				return gxTv_SdtGestionTareas_SDT_Trgestiontareas_descripcion; 
			}
			set { 
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_descripcion = value;
				SetDirty("Trgestiontareas_descripcion");
			}
		}



		[SoapElement(ElementName="TrGestionTareas_FechaInicio")]
		[XmlElement(ElementName="TrGestionTareas_FechaInicio" , IsNullable=true)]
		public string gxTpr_Trgestiontareas_fechainicio_Nullable
		{
			get {
				if ( gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechainicio == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechainicio).value ;
			}
			set {
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechainicio = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trgestiontareas_fechainicio
		{
			get { 
				return gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechainicio; 
			}
			set { 
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechainicio = value;
				SetDirty("Trgestiontareas_fechainicio");
			}
		}


		[SoapElement(ElementName="TrGestionTareas_FechaFin")]
		[XmlElement(ElementName="TrGestionTareas_FechaFin" , IsNullable=true)]
		public string gxTpr_Trgestiontareas_fechafin_Nullable
		{
			get {
				if ( gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechafin == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechafin).value ;
			}
			set {
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechafin = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trgestiontareas_fechafin
		{
			get { 
				return gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechafin; 
			}
			set { 
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechafin = value;
				SetDirty("Trgestiontareas_fechafin");
			}
		}


		[SoapElement(ElementName="TrGestionTareas_FechaCreacion")]
		[XmlElement(ElementName="TrGestionTareas_FechaCreacion" , IsNullable=true)]
		public string gxTpr_Trgestiontareas_fechacreacion_Nullable
		{
			get {
				if ( gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechacreacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechacreacion).value ;
			}
			set {
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trgestiontareas_fechacreacion
		{
			get { 
				return gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechacreacion; 
			}
			set { 
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechacreacion = value;
				SetDirty("Trgestiontareas_fechacreacion");
			}
		}


		[SoapElement(ElementName="TrGestionTareas_FechaModificacion")]
		[XmlElement(ElementName="TrGestionTareas_FechaModificacion" , IsNullable=true)]
		public string gxTpr_Trgestiontareas_fechamodificacion_Nullable
		{
			get {
				if ( gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechamodificacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechamodificacion).value ;
			}
			set {
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trgestiontareas_fechamodificacion
		{
			get { 
				return gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechamodificacion; 
			}
			set { 
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechamodificacion = value;
				SetDirty("Trgestiontareas_fechamodificacion");
			}
		}



		[SoapElement(ElementName="TrGestionTareas_Estado")]
		[XmlElement(ElementName="TrGestionTareas_Estado")]
		public short gxTpr_Trgestiontareas_estado
		{
			get { 
				return gxTv_SdtGestionTareas_SDT_Trgestiontareas_estado; 
			}
			set { 
				gxTv_SdtGestionTareas_SDT_Trgestiontareas_estado = value;
				SetDirty("Trgestiontareas_estado");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGestionTareas_SDT_Trgestiontareas_nombre = "";
			gxTv_SdtGestionTareas_SDT_Trgestiontareas_descripcion = "";





			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String sDateCnv ;
		protected String sNumToPad ;
		protected long gxTv_SdtGestionTareas_SDT_Trgestiontareas_id;
		 

		protected Guid gxTv_SdtGestionTareas_SDT_Trgestiontareas_idtablero;
		 

		protected String gxTv_SdtGestionTareas_SDT_Trgestiontareas_nombre;
		 

		protected String gxTv_SdtGestionTareas_SDT_Trgestiontareas_descripcion;
		 

		protected DateTime gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechainicio;
		 

		protected DateTime gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechafin;
		 

		protected DateTime gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechacreacion;
		 

		protected DateTime gxTv_SdtGestionTareas_SDT_Trgestiontareas_fechamodificacion;
		 

		protected short gxTv_SdtGestionTareas_SDT_Trgestiontareas_estado;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GestionTareas_SDT", Namespace="TABLEROS_WEB")]
	public class SdtGestionTareas_SDT_RESTInterface : GxGenericCollectionItem<SdtGestionTareas_SDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGestionTareas_SDT_RESTInterface( ) : base()
		{
		}

		public SdtGestionTareas_SDT_RESTInterface( SdtGestionTareas_SDT psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="TrGestionTareas_ID", Order=0)]
		public  String gxTpr_Trgestiontareas_id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Trgestiontareas_id, 13, 0));

			}
			set { 
				sdt.gxTpr_Trgestiontareas_id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TrGestionTareas_IDTablero", Order=1)]
		public Guid gxTpr_Trgestiontareas_idtablero
		{
			get { 
				return sdt.gxTpr_Trgestiontareas_idtablero;

			}
			set { 
				sdt.gxTpr_Trgestiontareas_idtablero = value;
			}
		}

		[DataMember(Name="TrGestionTareas_Nombre", Order=2)]
		public  String gxTpr_Trgestiontareas_nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Trgestiontareas_nombre);

			}
			set { 
				 sdt.gxTpr_Trgestiontareas_nombre = value;
			}
		}

		[DataMember(Name="TrGestionTareas_Descripcion", Order=3)]
		public  String gxTpr_Trgestiontareas_descripcion
		{
			get { 
				return sdt.gxTpr_Trgestiontareas_descripcion;

			}
			set { 
				 sdt.gxTpr_Trgestiontareas_descripcion = value;
			}
		}

		[DataMember(Name="TrGestionTareas_FechaInicio", Order=4)]
		public  String gxTpr_Trgestiontareas_fechainicio
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontareas_fechainicio);

			}
			set { 
				sdt.gxTpr_Trgestiontareas_fechainicio = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrGestionTareas_FechaFin", Order=5)]
		public  String gxTpr_Trgestiontareas_fechafin
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontareas_fechafin);

			}
			set { 
				sdt.gxTpr_Trgestiontareas_fechafin = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrGestionTareas_FechaCreacion", Order=6)]
		public  String gxTpr_Trgestiontareas_fechacreacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontareas_fechacreacion);

			}
			set { 
				sdt.gxTpr_Trgestiontareas_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrGestionTareas_FechaModificacion", Order=7)]
		public  String gxTpr_Trgestiontareas_fechamodificacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontareas_fechamodificacion);

			}
			set { 
				sdt.gxTpr_Trgestiontareas_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrGestionTareas_Estado", Order=8)]
		public short gxTpr_Trgestiontareas_estado
		{
			get { 
				return sdt.gxTpr_Trgestiontareas_estado;

			}
			set { 
				sdt.gxTpr_Trgestiontareas_estado = value;
			}
		}


		#endregion

		public SdtGestionTareas_SDT sdt
		{
			get { 
				return (SdtGestionTareas_SDT)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtGestionTareas_SDT() ;
			}
		}
	}
	#endregion
}