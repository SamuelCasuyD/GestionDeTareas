using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "TrGestionTableros" )]
   [XmlType(TypeName =  "TrGestionTableros" , Namespace = "TABLEROS_WEB" )]
   [Serializable]
   public class SdtTrGestionTableros : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTrGestionTableros( )
      {
      }

      public SdtTrGestionTableros( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override String JsonMap( String value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (String)mapper[value]; ;
      }

      public void Load( Guid AV1TrGestionTableros_ID )
      {
         IGxSilentTrn obj ;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV1TrGestionTableros_ID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TrGestionTableros_ID", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties() ;
         metadata.Set("Name", "TrGestionTableros");
         metadata.Set("BT", "TrGestionTableros");
         metadata.Set("PK", "[ \"TrGestionTableros_ID\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection() ;
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Trgestiontableros_id_Z");
         state.Add("gxTpr_Trgestiontableros_nombre_Z");
         state.Add("gxTpr_Trgestiontableros_fechainicio_Z_Nullable");
         state.Add("gxTpr_Trgestiontableros_fechafin_Z_Nullable");
         state.Add("gxTpr_Trgestiontableros_fechacreacion_Z_Nullable");
         state.Add("gxTpr_Trgestiontableros_fechamodificacion_Z_Nullable");
         state.Add("gxTpr_Trgestiontableros_nombre_N");
         state.Add("gxTpr_Trgestiontableros_comentario_N");
         state.Add("gxTpr_Trgestiontableros_descripcion_N");
         state.Add("gxTpr_Trgestiontableros_fechainicio_N");
         state.Add("gxTpr_Trgestiontableros_fechafin_N");
         state.Add("gxTpr_Trgestiontableros_fechacreacion_N");
         state.Add("gxTpr_Trgestiontableros_fechamodificacion_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrGestionTableros sdt ;
         sdt = (SdtTrGestionTableros)(source);
         gxTv_SdtTrGestionTableros_Trgestiontableros_id = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_id ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_nombre = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_nombre ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_comentario = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_comentario ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion ;
         gxTv_SdtTrGestionTableros_Mode = sdt.gxTv_SdtTrGestionTableros_Mode ;
         gxTv_SdtTrGestionTableros_Initialized = sdt.gxTv_SdtTrGestionTableros_Initialized ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N ;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("TrGestionTableros_ID", gxTv_SdtTrGestionTableros_Trgestiontableros_id, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_Nombre", gxTv_SdtTrGestionTableros_Trgestiontableros_nombre, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_Nombre_N", gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_Comentario", gxTv_SdtTrGestionTableros_Trgestiontableros_comentario, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_Comentario_N", gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_Descripcion", gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_Descripcion_N", gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TrGestionTableros_FechaInicio", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_FechaInicio_N", gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TrGestionTableros_FechaFin", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_FechaFin_N", gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TrGestionTableros_FechaCreacion", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_FechaCreacion_N", gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv = sDateCnv + "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion)), 10, 0));
         sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TrGestionTableros_FechaModificacion", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TrGestionTableros_FechaModificacion_N", gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrGestionTableros_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrGestionTableros_Initialized, false, includeNonInitialized);
            AddObjectProperty("TrGestionTableros_ID_Z", gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z, false, includeNonInitialized);
            AddObjectProperty("TrGestionTableros_Nombre_Z", gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TrGestionTableros_FechaInicio_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TrGestionTableros_FechaFin_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TrGestionTableros_FechaCreacion_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv = sDateCnv + "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z)), 10, 0));
            sDateCnv = sDateCnv + StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TrGestionTableros_FechaModificacion_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TrGestionTableros_Nombre_N", gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N, false, includeNonInitialized);
            AddObjectProperty("TrGestionTableros_Comentario_N", gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N, false, includeNonInitialized);
            AddObjectProperty("TrGestionTableros_Descripcion_N", gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N, false, includeNonInitialized);
            AddObjectProperty("TrGestionTableros_FechaInicio_N", gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N, false, includeNonInitialized);
            AddObjectProperty("TrGestionTableros_FechaFin_N", gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N, false, includeNonInitialized);
            AddObjectProperty("TrGestionTableros_FechaCreacion_N", gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N, false, includeNonInitialized);
            AddObjectProperty("TrGestionTableros_FechaModificacion_N", gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrGestionTableros sdt )
      {
         if ( sdt.IsDirty("TrGestionTableros_ID") )
         {
            gxTv_SdtTrGestionTableros_Trgestiontableros_id = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_id ;
         }
         if ( sdt.IsDirty("TrGestionTableros_Nombre") )
         {
            gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_nombre = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_nombre ;
         }
         if ( sdt.IsDirty("TrGestionTableros_Comentario") )
         {
            gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_comentario = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_comentario ;
         }
         if ( sdt.IsDirty("TrGestionTableros_Descripcion") )
         {
            gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion ;
         }
         if ( sdt.IsDirty("TrGestionTableros_FechaInicio") )
         {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio ;
         }
         if ( sdt.IsDirty("TrGestionTableros_FechaFin") )
         {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin ;
         }
         if ( sdt.IsDirty("TrGestionTableros_FechaCreacion") )
         {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion ;
         }
         if ( sdt.IsDirty("TrGestionTableros_FechaModificacion") )
         {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion = sdt.gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_ID" )]
      [  XmlElement( ElementName = "TrGestionTableros_ID"   )]
      public Guid gxTpr_Trgestiontableros_id
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_id ;
         }

         set {
            if ( gxTv_SdtTrGestionTableros_Trgestiontableros_id != value )
            {
               gxTv_SdtTrGestionTableros_Mode = "INS";
               this.gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z_SetNull( );
               this.gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z_SetNull( );
               this.gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z_SetNull( );
               this.gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z_SetNull( );
               this.gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z_SetNull( );
               this.gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z_SetNull( );
            }
            gxTv_SdtTrGestionTableros_Trgestiontableros_id = (Guid)(value);
            SetDirty("Trgestiontableros_id");
         }

      }

      [  SoapElement( ElementName = "TrGestionTableros_Nombre" )]
      [  XmlElement( ElementName = "TrGestionTableros_Nombre"   )]
      public String gxTpr_Trgestiontableros_nombre
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_nombre ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_nombre = value;
            SetDirty("Trgestiontableros_nombre");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N = 1;
         gxTv_SdtTrGestionTableros_Trgestiontableros_nombre = "";
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_IsNull( )
      {
         return (gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N==1) ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_Comentario" )]
      [  XmlElement( ElementName = "TrGestionTableros_Comentario"   )]
      public String gxTpr_Trgestiontableros_comentario
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_comentario ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_comentario = value;
            SetDirty("Trgestiontableros_comentario");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N = 1;
         gxTv_SdtTrGestionTableros_Trgestiontableros_comentario = "";
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_IsNull( )
      {
         return (gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N==1) ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_Descripcion" )]
      [  XmlElement( ElementName = "TrGestionTableros_Descripcion"   )]
      public String gxTpr_Trgestiontableros_descripcion
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion = value;
            SetDirty("Trgestiontableros_descripcion");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N = 1;
         gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion = "";
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_IsNull( )
      {
         return (gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N==1) ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaInicio" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaInicio"  , IsNullable=true )]
      public string gxTpr_Trgestiontableros_fechainicio_Nullable
      {
         get {
            if ( gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio).value ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio = DateTime.MinValue;
            else
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Trgestiontableros_fechainicio
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio = value;
            SetDirty("Trgestiontableros_fechainicio");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N = 1;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_IsNull( )
      {
         return (gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N==1) ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaFin" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaFin"  , IsNullable=true )]
      public string gxTpr_Trgestiontableros_fechafin_Nullable
      {
         get {
            if ( gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin).value ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin = DateTime.MinValue;
            else
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Trgestiontableros_fechafin
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin = value;
            SetDirty("Trgestiontableros_fechafin");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N = 1;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_IsNull( )
      {
         return (gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N==1) ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaCreacion" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaCreacion"  , IsNullable=true )]
      public string gxTpr_Trgestiontableros_fechacreacion_Nullable
      {
         get {
            if ( gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion).value ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion = DateTime.MinValue;
            else
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Trgestiontableros_fechacreacion
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion = value;
            SetDirty("Trgestiontableros_fechacreacion");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N = 1;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_IsNull( )
      {
         return (gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N==1) ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaModificacion" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaModificacion"  , IsNullable=true )]
      public string gxTpr_Trgestiontableros_fechamodificacion_Nullable
      {
         get {
            if ( gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion).value ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion = DateTime.MinValue;
            else
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Trgestiontableros_fechamodificacion
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N = 0;
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion = value;
            SetDirty("Trgestiontableros_fechamodificacion");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N = 1;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_IsNull( )
      {
         return (gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public String gxTpr_Mode
      {
         get {
            return gxTv_SdtTrGestionTableros_Mode ;
         }

         set {
            gxTv_SdtTrGestionTableros_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrGestionTableros_Mode_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Mode = "";
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrGestionTableros_Initialized ;
         }

         set {
            gxTv_SdtTrGestionTableros_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrGestionTableros_Initialized_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_ID_Z" )]
      [  XmlElement( ElementName = "TrGestionTableros_ID_Z"   )]
      public Guid gxTpr_Trgestiontableros_id_Z
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z = (Guid)(value);
            SetDirty("Trgestiontableros_id_Z");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z = (Guid)(Guid.Empty);
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_Nombre_Z" )]
      [  XmlElement( ElementName = "TrGestionTableros_Nombre_Z"   )]
      public String gxTpr_Trgestiontableros_nombre_Z
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z = value;
            SetDirty("Trgestiontableros_nombre_Z");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z = "";
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaInicio_Z" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaInicio_Z"  , IsNullable=true )]
      public string gxTpr_Trgestiontableros_fechainicio_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z = DateTime.MinValue;
            else
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Trgestiontableros_fechainicio_Z
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z = value;
            SetDirty("Trgestiontableros_fechainicio_Z");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaFin_Z" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaFin_Z"  , IsNullable=true )]
      public string gxTpr_Trgestiontableros_fechafin_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z = DateTime.MinValue;
            else
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Trgestiontableros_fechafin_Z
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z = value;
            SetDirty("Trgestiontableros_fechafin_Z");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaCreacion_Z" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaCreacion_Z"  , IsNullable=true )]
      public string gxTpr_Trgestiontableros_fechacreacion_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z = DateTime.MinValue;
            else
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Trgestiontableros_fechacreacion_Z
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z = value;
            SetDirty("Trgestiontableros_fechacreacion_Z");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaModificacion_Z" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaModificacion_Z"  , IsNullable=true )]
      public string gxTpr_Trgestiontableros_fechamodificacion_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z).value ;
         }

         set {
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z = DateTime.MinValue;
            else
               gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Trgestiontableros_fechamodificacion_Z
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z = value;
            SetDirty("Trgestiontableros_fechamodificacion_Z");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_Nombre_N" )]
      [  XmlElement( ElementName = "TrGestionTableros_Nombre_N"   )]
      public short gxTpr_Trgestiontableros_nombre_N
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N = value;
            SetDirty("Trgestiontableros_nombre_N");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N = 0;
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_Comentario_N" )]
      [  XmlElement( ElementName = "TrGestionTableros_Comentario_N"   )]
      public short gxTpr_Trgestiontableros_comentario_N
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N = value;
            SetDirty("Trgestiontableros_comentario_N");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N = 0;
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_Descripcion_N" )]
      [  XmlElement( ElementName = "TrGestionTableros_Descripcion_N"   )]
      public short gxTpr_Trgestiontableros_descripcion_N
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N = value;
            SetDirty("Trgestiontableros_descripcion_N");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N = 0;
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaInicio_N" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaInicio_N"   )]
      public short gxTpr_Trgestiontableros_fechainicio_N
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N = value;
            SetDirty("Trgestiontableros_fechainicio_N");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N = 0;
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaFin_N" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaFin_N"   )]
      public short gxTpr_Trgestiontableros_fechafin_N
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N = value;
            SetDirty("Trgestiontableros_fechafin_N");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N = 0;
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaCreacion_N" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaCreacion_N"   )]
      public short gxTpr_Trgestiontableros_fechacreacion_N
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N = value;
            SetDirty("Trgestiontableros_fechacreacion_N");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N = 0;
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TrGestionTableros_FechaModificacion_N" )]
      [  XmlElement( ElementName = "TrGestionTableros_FechaModificacion_N"   )]
      public short gxTpr_Trgestiontableros_fechamodificacion_N
      {
         get {
            return gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N ;
         }

         set {
            gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N = value;
            SetDirty("Trgestiontableros_fechamodificacion_N");
         }

      }

      public void gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N_SetNull( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N = 0;
         return  ;
      }

      public bool gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTrGestionTableros_Trgestiontableros_id = (Guid)(Guid.Empty);
         gxTv_SdtTrGestionTableros_Trgestiontableros_nombre = "";
         gxTv_SdtTrGestionTableros_Trgestiontableros_comentario = "";
         gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion = "";
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio = DateTime.MinValue;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin = DateTime.MinValue;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion = DateTime.MinValue;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion = DateTime.MinValue;
         gxTv_SdtTrGestionTableros_Mode = "";
         gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z = (Guid)(Guid.Empty);
         gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z = "";
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z = DateTime.MinValue;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z = DateTime.MinValue;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z = DateTime.MinValue;
         gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj ;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trgestiontableros", "GeneXus.Programs.trgestiontableros_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdtTrGestionTableros_Initialized ;
      private short gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_N ;
      private short gxTv_SdtTrGestionTableros_Trgestiontableros_comentario_N ;
      private short gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion_N ;
      private short gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_N ;
      private short gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_N ;
      private short gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_N ;
      private short gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_N ;
      private String gxTv_SdtTrGestionTableros_Trgestiontableros_nombre ;
      private String gxTv_SdtTrGestionTableros_Mode ;
      private String gxTv_SdtTrGestionTableros_Trgestiontableros_nombre_Z ;
      private String sDateCnv ;
      private String sNumToPad ;
      private DateTime gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio ;
      private DateTime gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin ;
      private DateTime gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion ;
      private DateTime gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion ;
      private DateTime gxTv_SdtTrGestionTableros_Trgestiontableros_fechainicio_Z ;
      private DateTime gxTv_SdtTrGestionTableros_Trgestiontableros_fechafin_Z ;
      private DateTime gxTv_SdtTrGestionTableros_Trgestiontableros_fechacreacion_Z ;
      private DateTime gxTv_SdtTrGestionTableros_Trgestiontableros_fechamodificacion_Z ;
      private String gxTv_SdtTrGestionTableros_Trgestiontableros_comentario ;
      private String gxTv_SdtTrGestionTableros_Trgestiontableros_descripcion ;
      private Guid gxTv_SdtTrGestionTableros_Trgestiontableros_id ;
      private Guid gxTv_SdtTrGestionTableros_Trgestiontableros_id_Z ;
   }

   [DataContract(Name = @"TrGestionTableros", Namespace = "TABLEROS_WEB")]
   public class SdtTrGestionTableros_RESTInterface : GxGenericCollectionItem<SdtTrGestionTableros>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTrGestionTableros_RESTInterface( ) : base()
      {
      }

      public SdtTrGestionTableros_RESTInterface( SdtTrGestionTableros psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TrGestionTableros_ID" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Trgestiontableros_id
      {
         get {
            return sdt.gxTpr_Trgestiontableros_id ;
         }

         set {
            sdt.gxTpr_Trgestiontableros_id = (Guid)(value);
         }

      }

      [DataMember( Name = "TrGestionTableros_Nombre" , Order = 1 )]
      [GxSeudo()]
      public String gxTpr_Trgestiontableros_nombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Trgestiontableros_nombre) ;
         }

         set {
            sdt.gxTpr_Trgestiontableros_nombre = value;
         }

      }

      [DataMember( Name = "TrGestionTableros_Comentario" , Order = 2 )]
      public String gxTpr_Trgestiontableros_comentario
      {
         get {
            return sdt.gxTpr_Trgestiontableros_comentario ;
         }

         set {
            sdt.gxTpr_Trgestiontableros_comentario = value;
         }

      }

      [DataMember( Name = "TrGestionTableros_Descripcion" , Order = 3 )]
      public String gxTpr_Trgestiontableros_descripcion
      {
         get {
            return sdt.gxTpr_Trgestiontableros_descripcion ;
         }

         set {
            sdt.gxTpr_Trgestiontableros_descripcion = value;
         }

      }

      [DataMember( Name = "TrGestionTableros_FechaInicio" , Order = 4 )]
      [GxSeudo()]
      public String gxTpr_Trgestiontableros_fechainicio
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontableros_fechainicio) ;
         }

         set {
            sdt.gxTpr_Trgestiontableros_fechainicio = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TrGestionTableros_FechaFin" , Order = 5 )]
      [GxSeudo()]
      public String gxTpr_Trgestiontableros_fechafin
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontableros_fechafin) ;
         }

         set {
            sdt.gxTpr_Trgestiontableros_fechafin = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TrGestionTableros_FechaCreacion" , Order = 6 )]
      [GxSeudo()]
      public String gxTpr_Trgestiontableros_fechacreacion
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontableros_fechacreacion) ;
         }

         set {
            sdt.gxTpr_Trgestiontableros_fechacreacion = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TrGestionTableros_FechaModificacion" , Order = 7 )]
      [GxSeudo()]
      public String gxTpr_Trgestiontableros_fechamodificacion
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontableros_fechamodificacion) ;
         }

         set {
            sdt.gxTpr_Trgestiontableros_fechamodificacion = DateTimeUtil.CToD2( value);
         }

      }

      public SdtTrGestionTableros sdt
      {
         get {
            return (SdtTrGestionTableros)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrGestionTableros() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 8 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (String)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private String md5Hash ;
   }

}
