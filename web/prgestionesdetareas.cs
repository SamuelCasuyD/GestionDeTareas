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
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prgestionesdetareas : GXProcedure
   {
      public prgestionesdetareas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public prgestionesdetareas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( SdtGestionTareas_SDT aP0_GestionTareas_SDT ,
                           SdtTrComentarioTarea_SDT aP1_TrComentarioTarea_SDT ,
                           String aP2_Modo )
      {
         this.AV9GestionTareas_SDT = aP0_GestionTareas_SDT;
         this.AV10TrComentarioTarea_SDT = aP1_TrComentarioTarea_SDT;
         this.AV8Modo = aP2_Modo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( SdtGestionTareas_SDT aP0_GestionTareas_SDT ,
                                 SdtTrComentarioTarea_SDT aP1_TrComentarioTarea_SDT ,
                                 String aP2_Modo )
      {
         prgestionesdetareas objprgestionesdetareas;
         objprgestionesdetareas = new prgestionesdetareas();
         objprgestionesdetareas.AV9GestionTareas_SDT = aP0_GestionTareas_SDT;
         objprgestionesdetareas.AV10TrComentarioTarea_SDT = aP1_TrComentarioTarea_SDT;
         objprgestionesdetareas.AV8Modo = aP2_Modo;
         objprgestionesdetareas.context.SetSubmitInitialConfig(context);
         objprgestionesdetareas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprgestionesdetareas);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prgestionesdetareas)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV8Modo, "INS") == 0 )
         {
            /* Execute user subroutine: 'NUEVATAREA' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Tarea creada");
         }
         else if ( StringUtil.StrCmp(AV8Modo, "UDP") == 0 )
         {
            /* Execute user subroutine: 'ACTUALIZARTAREA' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Tarea actualizada");
         }
         else if ( StringUtil.StrCmp(AV8Modo, "DEL") == 0 )
         {
            /* Execute user subroutine: 'ELIMINARTAREA' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Tarea Eliminada");
         }
         else if ( StringUtil.StrCmp(AV8Modo, "CIN") == 0 )
         {
            /* Execute user subroutine: 'AGREGARCOMENTARIOS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Comentario agregado Exitosamente...");
         }
         context.CommitDataStores("prgestionesdetareas",pr_default);
         this.cleanup();
         if (true) return;
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'NUEVATAREA' Routine */
         /*
            INSERT RECORD ON TABLE TrGestionTareas

         */
         A11TrGestionTareas_IDTablero = (Guid)(AV9GestionTareas_SDT.gxTpr_Trgestiontareas_idtablero);
         A13TrGestionTareas_Nombre = AV9GestionTareas_SDT.gxTpr_Trgestiontareas_nombre;
         n13TrGestionTareas_Nombre = false;
         A14TrGestionTareas_Descripcion = AV9GestionTareas_SDT.gxTpr_Trgestiontareas_descripcion;
         n14TrGestionTareas_Descripcion = false;
         A15TrGestionTareas_FechaInicio = AV9GestionTareas_SDT.gxTpr_Trgestiontareas_fechainicio;
         n15TrGestionTareas_FechaInicio = false;
         A16TrGestionTareas_FechaFin = AV9GestionTareas_SDT.gxTpr_Trgestiontareas_fechafin;
         n16TrGestionTareas_FechaFin = false;
         A17TrGestionTareas_FechaCreacion = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         n17TrGestionTareas_FechaCreacion = false;
         A24TrGestionTareas_Estado = 1;
         n24TrGestionTareas_Estado = false;
         /* Using cursor P002M2 */
         pr_default.execute(0, new Object[] {A11TrGestionTareas_IDTablero, n13TrGestionTareas_Nombre, A13TrGestionTareas_Nombre, n14TrGestionTareas_Descripcion, A14TrGestionTareas_Descripcion, n15TrGestionTareas_FechaInicio, A15TrGestionTareas_FechaInicio, n16TrGestionTareas_FechaFin, A16TrGestionTareas_FechaFin, n17TrGestionTareas_FechaCreacion, A17TrGestionTareas_FechaCreacion, n24TrGestionTareas_Estado, A24TrGestionTareas_Estado});
         A12TrGestionTareas_ID = P002M2_A12TrGestionTareas_ID[0];
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("TrGestionTareas") ;
         if ( (pr_default.getStatus(0) == 1) )
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

      protected void S121( )
      {
         /* 'ACTUALIZARTAREA' Routine */
         /* Optimized UPDATE. */
         /* Using cursor P002M3 */
         pr_default.execute(1, new Object[] {n24TrGestionTareas_Estado, AV9GestionTareas_SDT.gxTpr_Trgestiontareas_estado, n16TrGestionTareas_FechaFin, AV9GestionTareas_SDT.gxTpr_Trgestiontareas_fechafin, n15TrGestionTareas_FechaInicio, AV9GestionTareas_SDT.gxTpr_Trgestiontareas_fechainicio, n14TrGestionTareas_Descripcion, AV9GestionTareas_SDT.gxTpr_Trgestiontareas_descripcion, n13TrGestionTareas_Nombre, AV9GestionTareas_SDT.gxTpr_Trgestiontareas_nombre, AV9GestionTareas_SDT.gxTpr_Trgestiontareas_id, AV9GestionTareas_SDT.gxTpr_Trgestiontareas_idtablero});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("TrGestionTareas") ;
         /* End optimized UPDATE. */
      }

      protected void S131( )
      {
         /* 'ELIMINARTAREA' Routine */
      }

      protected void S141( )
      {
         /* 'AGREGARCOMENTARIOS' Routine */
         /*
            INSERT RECORD ON TABLE TrTareaComentarios

         */
         A34TrTareaComentarios_IDTarea = AV10TrComentarioTarea_SDT.gxTpr_Trtareacomentarios_idtarea;
         n34TrTareaComentarios_IDTarea = false;
         A36TrTareaComentarios_Descripcion = AV10TrComentarioTarea_SDT.gxTpr_Trtareacomentarios_descripcion;
         n36TrTareaComentarios_Descripcion = false;
         A38TrTareaComentarios_FechaCreacion = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         n38TrTareaComentarios_FechaCreacion = false;
         A37TrTareaComentarios_Estado = AV10TrComentarioTarea_SDT.gxTpr_Trtareacomentarios_estado;
         n37TrTareaComentarios_Estado = false;
         /* Using cursor P002M4 */
         pr_default.execute(2, new Object[] {n34TrTareaComentarios_IDTarea, A34TrTareaComentarios_IDTarea, n36TrTareaComentarios_Descripcion, A36TrTareaComentarios_Descripcion, n37TrTareaComentarios_Estado, A37TrTareaComentarios_Estado, n38TrTareaComentarios_FechaCreacion, A38TrTareaComentarios_FechaCreacion});
         A35TrTareaComentarios_ID = P002M4_A35TrTareaComentarios_ID[0];
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("TrTareaComentarios") ;
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

      public override void cleanup( )
      {
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
         A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         A13TrGestionTareas_Nombre = "";
         A14TrGestionTareas_Descripcion = "";
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
         A17TrGestionTareas_FechaCreacion = DateTime.MinValue;
         P002M2_A12TrGestionTareas_ID = new long[1] ;
         Gx_emsg = "";
         A36TrTareaComentarios_Descripcion = "";
         A38TrTareaComentarios_FechaCreacion = DateTime.MinValue;
         P002M4_A35TrTareaComentarios_ID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prgestionesdetareas__default(),
            new Object[][] {
                new Object[] {
               P002M2_A12TrGestionTareas_ID
               }
               , new Object[] {
               }
               , new Object[] {
               P002M4_A35TrTareaComentarios_ID
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A24TrGestionTareas_Estado ;
      private short A37TrTareaComentarios_Estado ;
      private int GX_INS2 ;
      private int GX_INS5 ;
      private long A12TrGestionTareas_ID ;
      private long A34TrTareaComentarios_IDTarea ;
      private long A35TrTareaComentarios_ID ;
      private String AV8Modo ;
      private String A13TrGestionTareas_Nombre ;
      private String Gx_emsg ;
      private DateTime A15TrGestionTareas_FechaInicio ;
      private DateTime A16TrGestionTareas_FechaFin ;
      private DateTime A17TrGestionTareas_FechaCreacion ;
      private DateTime A38TrTareaComentarios_FechaCreacion ;
      private bool returnInSub ;
      private bool n13TrGestionTareas_Nombre ;
      private bool n14TrGestionTareas_Descripcion ;
      private bool n15TrGestionTareas_FechaInicio ;
      private bool n16TrGestionTareas_FechaFin ;
      private bool n17TrGestionTareas_FechaCreacion ;
      private bool n24TrGestionTareas_Estado ;
      private bool n34TrTareaComentarios_IDTarea ;
      private bool n36TrTareaComentarios_Descripcion ;
      private bool n38TrTareaComentarios_FechaCreacion ;
      private bool n37TrTareaComentarios_Estado ;
      private String A14TrGestionTareas_Descripcion ;
      private String A36TrTareaComentarios_Descripcion ;
      private Guid A11TrGestionTareas_IDTablero ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002M2_A12TrGestionTareas_ID ;
      private long[] P002M4_A35TrTareaComentarios_ID ;
      private SdtGestionTareas_SDT AV9GestionTareas_SDT ;
      private SdtTrComentarioTarea_SDT AV10TrComentarioTarea_SDT ;
   }

   public class prgestionesdetareas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002M2 ;
          prmP002M2 = new Object[] {
          new Object[] {"@TrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@TrGestionTareas_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTareas_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTareas_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_Estado",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmP002M3 ;
          prmP002M3 = new Object[] {
          new Object[] {"@TrGestionTareas_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTareas_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTareas_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTareas_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@AV9Gesti_1Trgestiontareas_id",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV9Gesti_2Trgestiontareas_idt",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmP002M4 ;
          prmP002M4 = new Object[] {
          new Object[] {"@TrTareaComentarios_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrTareaComentarios_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrTareaComentarios_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrTareaComentarios_FechaCreacion",SqlDbType.DateTime,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P002M2", "INSERT INTO TABLERO.[TrGestionTareas]([TrGestionTareas_IDTablero], [TrGestionTareas_Nombre], [TrGestionTareas_Descripcion], [TrGestionTareas_FechaInicio], [TrGestionTareas_FechaFin], [TrGestionTareas_FechaCreacion], [TrGestionTareas_Estado], [TrGestionTareas_FechaModificacion]) VALUES(@TrGestionTareas_IDTablero, @TrGestionTareas_Nombre, @TrGestionTareas_Descripcion, @TrGestionTareas_FechaInicio, @TrGestionTareas_FechaFin, @TrGestionTareas_FechaCreacion, @TrGestionTareas_Estado, convert( DATETIME, '17530101', 112 )); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP002M2)
             ,new CursorDef("P002M3", "UPDATE TABLERO.[TrGestionTareas] SET [TrGestionTareas_Estado]=@TrGestionTareas_Estado, [TrGestionTareas_FechaModificacion]=GETUTCDATE(), [TrGestionTareas_FechaFin]=@TrGestionTareas_FechaFin, [TrGestionTareas_FechaInicio]=@TrGestionTareas_FechaInicio, [TrGestionTareas_Descripcion]=@TrGestionTareas_Descripcion, [TrGestionTareas_Nombre]=@TrGestionTareas_Nombre  WHERE ([TrGestionTareas_ID] = @AV9Gesti_1Trgestiontareas_id) AND ([TrGestionTareas_IDTablero] = @AV9Gesti_2Trgestiontareas_idt)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002M3)
             ,new CursorDef("P002M4", "INSERT INTO TABLERO.[TrTareaComentarios]([TrTareaComentarios_IDTarea], [TrTareaComentarios_Descripcion], [TrTareaComentarios_Estado], [TrTareaComentarios_FechaCreacion], [TrTareaComentarios_FechaModificacion]) VALUES(@TrTareaComentarios_IDTarea, @TrTareaComentarios_Descripcion, @TrTareaComentarios_Estado, @TrTareaComentarios_FechaCreacion, convert( DATETIME, '17530101', 112 )); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP002M4)
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
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
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
                   stmt.setNull( 3 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[4]);
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
                   stmt.setNull( 7 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(7, (short)parms[12]);
                }
                return;
             case 1 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(1, (short)parms[1]);
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
                   stmt.setNull( 4 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(4, (String)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(5, (String)parms[9]);
                }
                stmt.SetParameter(6, (long)parms[10]);
                stmt.SetParameter(7, (Guid)parms[11]);
                return;
             case 2 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(1, (long)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(3, (short)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(4, (DateTime)parms[7]);
                }
                return;
       }
    }

 }

}
