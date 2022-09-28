using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wsgestiontareas : GXProcedure
   {
      public wsgestiontareas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wsgestiontareas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( short aP0_Accion ,
                           GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> aP1_WsGestionTablero ,
                           out GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> aP2_GestionTableros_SDT )
      {
         this.AV12Accion = aP0_Accion;
         this.AV13WsGestionTablero = aP1_WsGestionTablero;
         this.AV8GestionTableros_SDT = new GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem>( context, "GestionTableros_SDTItem", "TABLEROS_WEB") ;
         initialize();
         executePrivate();
         aP2_GestionTableros_SDT=this.AV8GestionTableros_SDT;
      }

      public GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> executeUdp( short aP0_Accion ,
                                                                                          GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> aP1_WsGestionTablero )
      {
         execute(aP0_Accion, aP1_WsGestionTablero, out aP2_GestionTableros_SDT);
         return AV8GestionTableros_SDT ;
      }

      public void executeSubmit( short aP0_Accion ,
                                 GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> aP1_WsGestionTablero ,
                                 out GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> aP2_GestionTableros_SDT )
      {
         wsgestiontareas objwsgestiontareas;
         objwsgestiontareas = new wsgestiontareas();
         objwsgestiontareas.AV12Accion = aP0_Accion;
         objwsgestiontareas.AV13WsGestionTablero = aP1_WsGestionTablero;
         objwsgestiontareas.AV8GestionTableros_SDT = new GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem>( context, "GestionTableros_SDTItem", "TABLEROS_WEB") ;
         objwsgestiontareas.context.SetSubmitInitialConfig(context);
         objwsgestiontareas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwsgestiontareas);
         aP2_GestionTableros_SDT=this.AV8GestionTableros_SDT;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wsgestiontareas)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( AV12Accion != 0 )
         {
            if ( AV12Accion == 1 )
            {
               /* Execute user subroutine: 'CONSULTARTABLEROS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            else if ( AV12Accion == 2 )
            {
               /* Execute user subroutine: 'INSERTARTABLERO' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Using cursor P000C2 */
               pr_default.execute(0, new Object[] {AV21GUID});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A1TrGestionTableros_ID = (Guid)((Guid)(P000C2_A1TrGestionTableros_ID[0]));
                  A2TrGestionTableros_Nombre = P000C2_A2TrGestionTableros_Nombre[0];
                  n2TrGestionTableros_Nombre = P000C2_n2TrGestionTableros_Nombre[0];
                  A5TrGestionTableros_Descripcion = P000C2_A5TrGestionTableros_Descripcion[0];
                  n5TrGestionTableros_Descripcion = P000C2_n5TrGestionTableros_Descripcion[0];
                  A6TrGestionTableros_Comentario = P000C2_A6TrGestionTableros_Comentario[0];
                  n6TrGestionTableros_Comentario = P000C2_n6TrGestionTableros_Comentario[0];
                  A3TrGestionTableros_FechaInicio = P000C2_A3TrGestionTableros_FechaInicio[0];
                  n3TrGestionTableros_FechaInicio = P000C2_n3TrGestionTableros_FechaInicio[0];
                  A4TrGestionTableros_FechaFin = P000C2_A4TrGestionTableros_FechaFin[0];
                  n4TrGestionTableros_FechaFin = P000C2_n4TrGestionTableros_FechaFin[0];
                  A7TrGestionTableros_FechaCreacion = P000C2_A7TrGestionTableros_FechaCreacion[0];
                  n7TrGestionTableros_FechaCreacion = P000C2_n7TrGestionTableros_FechaCreacion[0];
                  A8TrGestionTableros_FechaModificacion = P000C2_A8TrGestionTableros_FechaModificacion[0];
                  n8TrGestionTableros_FechaModificacion = P000C2_n8TrGestionTableros_FechaModificacion[0];
                  AV10TableroTareas = new SdtGestionTableros_SDT_GestionTableros_SDTItem(context);
                  AV10TableroTareas.gxTpr_Trgestiontableros_id = (Guid)(A1TrGestionTableros_ID);
                  AV10TableroTareas.gxTpr_Trgestiontableros_nombre = A2TrGestionTableros_Nombre;
                  AV10TableroTareas.gxTpr_Trgestiontableros_descripcion = A5TrGestionTableros_Descripcion;
                  AV10TableroTareas.gxTpr_Trgestiontableros_comentario = A6TrGestionTableros_Comentario;
                  AV10TableroTareas.gxTpr_Trgestiontableros_fechainicio = A3TrGestionTableros_FechaInicio;
                  AV10TableroTareas.gxTpr_Trgestiontableros_fechafin = A4TrGestionTableros_FechaFin;
                  AV10TableroTareas.gxTpr_Trgestiontableros_fechacreacion = A7TrGestionTableros_FechaCreacion;
                  AV10TableroTareas.gxTpr_Trgestiontableros_fechamodificacion = A8TrGestionTableros_FechaModificacion;
                  AV8GestionTableros_SDT.Add(AV10TableroTareas, 0);
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(0);
            }
            else if ( AV12Accion == 3 )
            {
               /* Execute user subroutine: 'ACTUALIZARTABLERO' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            else if ( AV12Accion == 4 )
            {
               /* Execute user subroutine: 'ELIMINARTABLERO' */
               S141 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CONSULTARTABLEROS' Routine */
         /* Using cursor P000C3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1TrGestionTableros_ID = (Guid)((Guid)(P000C3_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = P000C3_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = P000C3_n2TrGestionTableros_Nombre[0];
            A5TrGestionTableros_Descripcion = P000C3_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = P000C3_n5TrGestionTableros_Descripcion[0];
            A6TrGestionTableros_Comentario = P000C3_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = P000C3_n6TrGestionTableros_Comentario[0];
            A3TrGestionTableros_FechaInicio = P000C3_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = P000C3_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = P000C3_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = P000C3_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = P000C3_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = P000C3_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = P000C3_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = P000C3_n8TrGestionTableros_FechaModificacion[0];
            AV10TableroTareas = new SdtGestionTableros_SDT_GestionTableros_SDTItem(context);
            AV10TableroTareas.gxTpr_Trgestiontableros_id = (Guid)(A1TrGestionTableros_ID);
            AV10TableroTareas.gxTpr_Trgestiontableros_nombre = A2TrGestionTableros_Nombre;
            AV10TableroTareas.gxTpr_Trgestiontableros_descripcion = A5TrGestionTableros_Descripcion;
            AV10TableroTareas.gxTpr_Trgestiontableros_comentario = A6TrGestionTableros_Comentario;
            AV10TableroTareas.gxTpr_Trgestiontableros_fechainicio = A3TrGestionTableros_FechaInicio;
            AV10TableroTareas.gxTpr_Trgestiontableros_fechafin = A4TrGestionTableros_FechaFin;
            AV10TableroTareas.gxTpr_Trgestiontableros_fechacreacion = A7TrGestionTableros_FechaCreacion;
            AV10TableroTareas.gxTpr_Trgestiontableros_fechamodificacion = A8TrGestionTableros_FechaModificacion;
            AV8GestionTableros_SDT.Add(AV10TableroTareas, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'INSERTARTABLERO' Routine */
         AV21GUID = (Guid)(Guid.NewGuid( ));
         /*
            INSERT RECORD ON TABLE TrGestionTableros

         */
         A1TrGestionTableros_ID = (Guid)(AV21GUID);
         A2TrGestionTableros_Nombre = AV17GestionTablero.gxTpr_Trgestiontableros_nombre;
         n2TrGestionTableros_Nombre = false;
         A5TrGestionTableros_Descripcion = AV17GestionTablero.gxTpr_Trgestiontableros_descripcion;
         n5TrGestionTableros_Descripcion = false;
         A6TrGestionTableros_Comentario = AV17GestionTablero.gxTpr_Trgestiontableros_comentario;
         n6TrGestionTableros_Comentario = false;
         A3TrGestionTableros_FechaInicio = AV17GestionTablero.gxTpr_Trgestiontableros_fechainicio;
         n3TrGestionTableros_FechaInicio = false;
         A4TrGestionTableros_FechaFin = AV17GestionTablero.gxTpr_Trgestiontableros_fechafin;
         n4TrGestionTableros_FechaFin = false;
         A7TrGestionTableros_FechaCreacion = AV17GestionTablero.gxTpr_Trgestiontableros_fechacreacion;
         n7TrGestionTableros_FechaCreacion = false;
         A8TrGestionTableros_FechaModificacion = AV17GestionTablero.gxTpr_Trgestiontableros_fechamodificacion;
         n8TrGestionTableros_FechaModificacion = false;
         /* Using cursor P000C4 */
         pr_default.execute(2, new Object[] {A1TrGestionTableros_ID, n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n8TrGestionTableros_FechaModificacion, A8TrGestionTableros_FechaModificacion, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
         if ( (pr_default.getStatus(2) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (String)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
      }

      protected void S131( )
      {
         /* 'ACTUALIZARTABLERO' Routine */
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV13WsGestionTablero.Count )
         {
            AV17GestionTablero = ((SdtGestionTableros_SDT_GestionTableros_SDTItem)AV13WsGestionTablero.Item(AV26GXV1));
            /* Optimized UPDATE. */
            /* Using cursor P000C5 */
            pr_default.execute(3, new Object[] {n8TrGestionTableros_FechaModificacion, AV17GestionTablero.gxTpr_Trgestiontableros_fechamodificacion, n7TrGestionTableros_FechaCreacion, AV17GestionTablero.gxTpr_Trgestiontableros_fechacreacion, n4TrGestionTableros_FechaFin, AV17GestionTablero.gxTpr_Trgestiontableros_fechafin, n3TrGestionTableros_FechaInicio, AV17GestionTablero.gxTpr_Trgestiontableros_fechainicio, n6TrGestionTableros_Comentario, AV17GestionTablero.gxTpr_Trgestiontableros_comentario, n5TrGestionTableros_Descripcion, AV17GestionTablero.gxTpr_Trgestiontableros_descripcion, n2TrGestionTableros_Nombre, AV17GestionTablero.gxTpr_Trgestiontableros_nombre, AV17GestionTablero.gxTpr_Trgestiontableros_id});
            pr_default.close(3);
            dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
            /* End optimized UPDATE. */
            AV26GXV1 = (int)(AV26GXV1+1);
         }
      }

      protected void S141( )
      {
         /* 'ELIMINARTABLERO' Routine */
         AV28GXV2 = 1;
         while ( AV28GXV2 <= AV13WsGestionTablero.Count )
         {
            AV17GestionTablero = ((SdtGestionTableros_SDT_GestionTableros_SDTItem)AV13WsGestionTablero.Item(AV28GXV2));
            /* Optimized DELETE. */
            /* Using cursor P000C6 */
            pr_default.execute(4, new Object[] {AV17GestionTablero.gxTpr_Trgestiontableros_id});
            pr_default.close(4);
            dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
            /* End optimized DELETE. */
            AV28GXV2 = (int)(AV28GXV2+1);
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wsgestiontareas",pr_default);
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         scmdbuf = "";
         AV21GUID = (Guid)(Guid.Empty);
         P000C2_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         P000C2_A2TrGestionTableros_Nombre = new String[] {""} ;
         P000C2_n2TrGestionTableros_Nombre = new bool[] {false} ;
         P000C2_A5TrGestionTableros_Descripcion = new String[] {""} ;
         P000C2_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         P000C2_A6TrGestionTableros_Comentario = new String[] {""} ;
         P000C2_n6TrGestionTableros_Comentario = new bool[] {false} ;
         P000C2_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         P000C2_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         P000C2_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         P000C2_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         P000C2_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         P000C2_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         P000C2_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         P000C2_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A2TrGestionTableros_Nombre = "";
         A5TrGestionTableros_Descripcion = "";
         A6TrGestionTableros_Comentario = "";
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         AV10TableroTareas = new SdtGestionTableros_SDT_GestionTableros_SDTItem(context);
         P000C3_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         P000C3_A2TrGestionTableros_Nombre = new String[] {""} ;
         P000C3_n2TrGestionTableros_Nombre = new bool[] {false} ;
         P000C3_A5TrGestionTableros_Descripcion = new String[] {""} ;
         P000C3_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         P000C3_A6TrGestionTableros_Comentario = new String[] {""} ;
         P000C3_n6TrGestionTableros_Comentario = new bool[] {false} ;
         P000C3_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         P000C3_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         P000C3_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         P000C3_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         P000C3_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         P000C3_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         P000C3_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         P000C3_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         AV17GestionTablero = new SdtGestionTableros_SDT_GestionTableros_SDTItem(context);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wsgestiontareas__default(),
            new Object[][] {
                new Object[] {
               P000C2_A1TrGestionTableros_ID, P000C2_A2TrGestionTableros_Nombre, P000C2_n2TrGestionTableros_Nombre, P000C2_A5TrGestionTableros_Descripcion, P000C2_n5TrGestionTableros_Descripcion, P000C2_A6TrGestionTableros_Comentario, P000C2_n6TrGestionTableros_Comentario, P000C2_A3TrGestionTableros_FechaInicio, P000C2_n3TrGestionTableros_FechaInicio, P000C2_A4TrGestionTableros_FechaFin,
               P000C2_n4TrGestionTableros_FechaFin, P000C2_A7TrGestionTableros_FechaCreacion, P000C2_n7TrGestionTableros_FechaCreacion, P000C2_A8TrGestionTableros_FechaModificacion, P000C2_n8TrGestionTableros_FechaModificacion
               }
               , new Object[] {
               P000C3_A1TrGestionTableros_ID, P000C3_A2TrGestionTableros_Nombre, P000C3_n2TrGestionTableros_Nombre, P000C3_A5TrGestionTableros_Descripcion, P000C3_n5TrGestionTableros_Descripcion, P000C3_A6TrGestionTableros_Comentario, P000C3_n6TrGestionTableros_Comentario, P000C3_A3TrGestionTableros_FechaInicio, P000C3_n3TrGestionTableros_FechaInicio, P000C3_A4TrGestionTableros_FechaFin,
               P000C3_n4TrGestionTableros_FechaFin, P000C3_A7TrGestionTableros_FechaCreacion, P000C3_n7TrGestionTableros_FechaCreacion, P000C3_A8TrGestionTableros_FechaModificacion, P000C3_n8TrGestionTableros_FechaModificacion
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12Accion ;
      private int GX_INS1 ;
      private int AV26GXV1 ;
      private int AV28GXV2 ;
      private String scmdbuf ;
      private String A2TrGestionTableros_Nombre ;
      private String Gx_emsg ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private DateTime A8TrGestionTableros_FechaModificacion ;
      private bool returnInSub ;
      private bool n2TrGestionTableros_Nombre ;
      private bool n5TrGestionTableros_Descripcion ;
      private bool n6TrGestionTableros_Comentario ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n8TrGestionTableros_FechaModificacion ;
      private String A5TrGestionTableros_Descripcion ;
      private String A6TrGestionTableros_Comentario ;
      private Guid AV21GUID ;
      private Guid A1TrGestionTableros_ID ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P000C2_A1TrGestionTableros_ID ;
      private String[] P000C2_A2TrGestionTableros_Nombre ;
      private bool[] P000C2_n2TrGestionTableros_Nombre ;
      private String[] P000C2_A5TrGestionTableros_Descripcion ;
      private bool[] P000C2_n5TrGestionTableros_Descripcion ;
      private String[] P000C2_A6TrGestionTableros_Comentario ;
      private bool[] P000C2_n6TrGestionTableros_Comentario ;
      private DateTime[] P000C2_A3TrGestionTableros_FechaInicio ;
      private bool[] P000C2_n3TrGestionTableros_FechaInicio ;
      private DateTime[] P000C2_A4TrGestionTableros_FechaFin ;
      private bool[] P000C2_n4TrGestionTableros_FechaFin ;
      private DateTime[] P000C2_A7TrGestionTableros_FechaCreacion ;
      private bool[] P000C2_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] P000C2_A8TrGestionTableros_FechaModificacion ;
      private bool[] P000C2_n8TrGestionTableros_FechaModificacion ;
      private Guid[] P000C3_A1TrGestionTableros_ID ;
      private String[] P000C3_A2TrGestionTableros_Nombre ;
      private bool[] P000C3_n2TrGestionTableros_Nombre ;
      private String[] P000C3_A5TrGestionTableros_Descripcion ;
      private bool[] P000C3_n5TrGestionTableros_Descripcion ;
      private String[] P000C3_A6TrGestionTableros_Comentario ;
      private bool[] P000C3_n6TrGestionTableros_Comentario ;
      private DateTime[] P000C3_A3TrGestionTableros_FechaInicio ;
      private bool[] P000C3_n3TrGestionTableros_FechaInicio ;
      private DateTime[] P000C3_A4TrGestionTableros_FechaFin ;
      private bool[] P000C3_n4TrGestionTableros_FechaFin ;
      private DateTime[] P000C3_A7TrGestionTableros_FechaCreacion ;
      private bool[] P000C3_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] P000C3_A8TrGestionTableros_FechaModificacion ;
      private bool[] P000C3_n8TrGestionTableros_FechaModificacion ;
      private GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> aP2_GestionTableros_SDT ;
      private GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> AV13WsGestionTablero ;
      private GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> AV8GestionTableros_SDT ;
      private SdtGestionTableros_SDT_GestionTableros_SDTItem AV10TableroTareas ;
      private SdtGestionTableros_SDT_GestionTableros_SDTItem AV17GestionTablero ;
   }

   public class wsgestiontareas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new UpdateCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000C2 ;
          prmP000C2 = new Object[] {
          new Object[] {"@AV21GUID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmP000C3 ;
          prmP000C3 = new Object[] {
          } ;
          Object[] prmP000C4 ;
          prmP000C4 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0}
          } ;
          Object[] prmP000C5 ;
          prmP000C5 = new Object[] {
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV17Gest_1Trgestiontableros_i",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmP000C6 ;
          prmP000C6 = new Object[] {
          new Object[] {"@AV17Gest_1Trgestiontableros_i",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000C2", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Descripcion], [TrGestionTableros_Comentario], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @AV21GUID ORDER BY [TrGestionTableros_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000C2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000C3", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Descripcion], [TrGestionTableros_Comentario], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion] FROM TABLERO.[TrGestionTableros] ORDER BY [TrGestionTableros_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000C3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P000C4", "INSERT INTO TABLERO.[TrGestionTableros]([TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_Estado]) VALUES(@TrGestionTableros_ID, @TrGestionTableros_Nombre, @TrGestionTableros_FechaInicio, @TrGestionTableros_FechaFin, @TrGestionTableros_FechaCreacion, @TrGestionTableros_FechaModificacion, @TrGestionTableros_Comentario, @TrGestionTableros_Descripcion, convert(int, 0), convert(bit, 0))", GxErrorMask.GX_NOMASK,prmP000C4)
             ,new CursorDef("P000C5", "UPDATE TABLERO.[TrGestionTableros] SET [TrGestionTableros_FechaModificacion]=@TrGestionTableros_FechaModificacion, [TrGestionTableros_FechaCreacion]=@TrGestionTableros_FechaCreacion, [TrGestionTableros_FechaFin]=@TrGestionTableros_FechaFin, [TrGestionTableros_FechaInicio]=@TrGestionTableros_FechaInicio, [TrGestionTableros_Comentario]=@TrGestionTableros_Comentario, [TrGestionTableros_Descripcion]=@TrGestionTableros_Descripcion, [TrGestionTableros_Nombre]=@TrGestionTableros_Nombre  WHERE [TrGestionTableros_ID] = @AV17Gest_1Trgestiontableros_i", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000C5)
             ,new CursorDef("P000C6", "DELETE FROM TABLERO.[TrGestionTableros]  WHERE [TrGestionTableros_ID] = @AV17Gest_1Trgestiontableros_i", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000C6)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (Guid)parms[0]);
                if ( (bool)parms[1] )
                {
                   stmt.setNull( 2 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[2]);
                }
                if ( (bool)parms[3] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(3, (DateTime)parms[4]);
                }
                if ( (bool)parms[5] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(4, (DateTime)parms[6]);
                }
                if ( (bool)parms[7] )
                {
                   stmt.setNull( 5 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(5, (DateTime)parms[8]);
                }
                if ( (bool)parms[9] )
                {
                   stmt.setNull( 6 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(6, (DateTime)parms[10]);
                }
                if ( (bool)parms[11] )
                {
                   stmt.setNull( 7 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(7, (String)parms[12]);
                }
                if ( (bool)parms[13] )
                {
                   stmt.setNull( 8 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(8, (String)parms[14]);
                }
                return;
             case 3 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(1, (DateTime)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(2, (DateTime)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(3, (DateTime)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(4, (DateTime)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(5, (String)parms[9]);
                }
                if ( (bool)parms[10] )
                {
                   stmt.setNull( 6 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(6, (String)parms[11]);
                }
                if ( (bool)parms[12] )
                {
                   stmt.setNull( 7 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(7, (String)parms[13]);
                }
                stmt.SetParameter(8, (Guid)parms[14]);
                return;
             case 4 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.wsgestiontareas_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class wsgestiontareas_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( short Accion ,
                         GxGenericCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem_RESTInterface> WsGestionTablero ,
                         out GxGenericCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem_RESTInterface> GestionTableros_SDT )
    {
       GestionTableros_SDT = new GxGenericCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem_RESTInterface>() ;
       try
       {
          if ( ! ProcessHeaders("wsgestiontareas") )
          {
             return  ;
          }
          wsgestiontareas worker = new wsgestiontareas(context) ;
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> gxrWsGestionTablero = new GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem>() ;
          WsGestionTablero.LoadCollection(gxrWsGestionTablero);
          GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem> gxrGestionTableros_SDT = new GXBaseCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem>() ;
          worker.execute(Accion,gxrWsGestionTablero,out gxrGestionTableros_SDT );
          worker.cleanup( );
          GestionTableros_SDT = new GxGenericCollection<SdtGestionTableros_SDT_GestionTableros_SDTItem_RESTInterface>(gxrGestionTableros_SDT) ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
    }

 }

}
