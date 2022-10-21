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
   public class prgestionaretiquetas : GXProcedure
   {
      public prgestionaretiquetas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public prgestionaretiquetas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( SdtGestionEtiquetas_SDT aP0_GestionEtiquetas_SDT ,
                           String aP1_Modo )
      {
         this.AV8GestionEtiquetas_SDT = aP0_GestionEtiquetas_SDT;
         this.AV9Modo = aP1_Modo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( SdtGestionEtiquetas_SDT aP0_GestionEtiquetas_SDT ,
                                 String aP1_Modo )
      {
         prgestionaretiquetas objprgestionaretiquetas;
         objprgestionaretiquetas = new prgestionaretiquetas();
         objprgestionaretiquetas.AV8GestionEtiquetas_SDT = aP0_GestionEtiquetas_SDT;
         objprgestionaretiquetas.AV9Modo = aP1_Modo;
         objprgestionaretiquetas.context.SetSubmitInitialConfig(context);
         objprgestionaretiquetas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprgestionaretiquetas);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prgestionaretiquetas)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV9Modo, "INS") == 0 )
         {
            /* Execute user subroutine: 'NUEVAETIQUETA' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Etiqueta creada");
         }
         else if ( StringUtil.StrCmp(AV9Modo, "UDP") == 0 )
         {
            /* Execute user subroutine: 'ACTUALIZARETIQUETA' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Etiqueta actualizada");
         }
         else if ( StringUtil.StrCmp(AV9Modo, "DEL") == 0 )
         {
            /* Execute user subroutine: 'ELIMINARETIQUETA' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Etiqueta Eliminada");
         }
         else if ( StringUtil.StrCmp(AV9Modo, "EIN") == 0 )
         {
            /* Execute user subroutine: 'AGREGARETIQUETA' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GX_msglist.addItem("Etiqueta agregada a la Tarea");
         }
         context.CommitDataStores("prgestionaretiquetas",pr_default);
         this.cleanup();
         if (true) return;
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'NUEVAETIQUETA' Routine */
         /*
            INSERT RECORD ON TABLE TrEtiquetas

         */
         A40TrEtiquetas_IDTarea = 0;
         n40TrEtiquetas_IDTarea = false;
         n40TrEtiquetas_IDTarea = true;
         A42TrEtiquetas_Nombre = AV8GestionEtiquetas_SDT.gxTpr_Tretiquetas_nombre;
         n42TrEtiquetas_Nombre = false;
         A43TrEtiquetas_FechaCreacion = DateTimeUtil.ResetTime(DateTimeUtil.ServerNow( context, pr_default));
         n43TrEtiquetas_FechaCreacion = false;
         A45TrEtiquetas_Estado = AV8GestionEtiquetas_SDT.gxTpr_Tretiquetas_estado;
         n45TrEtiquetas_Estado = false;
         /* Using cursor P002N2 */
         pr_default.execute(0, new Object[] {n42TrEtiquetas_Nombre, A42TrEtiquetas_Nombre, n43TrEtiquetas_FechaCreacion, A43TrEtiquetas_FechaCreacion, n45TrEtiquetas_Estado, A45TrEtiquetas_Estado, n40TrEtiquetas_IDTarea, A40TrEtiquetas_IDTarea});
         A41TrEtiquetas_ID = P002N2_A41TrEtiquetas_ID[0];
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("TrEtiquetas") ;
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
         /* 'ACTUALIZARETIQUETA' Routine */
         /* Optimized UPDATE. */
         /* Using cursor P002N3 */
         pr_default.execute(1, new Object[] {n45TrEtiquetas_Estado, AV8GestionEtiquetas_SDT.gxTpr_Tretiquetas_estado, n42TrEtiquetas_Nombre, AV8GestionEtiquetas_SDT.gxTpr_Tretiquetas_nombre, AV8GestionEtiquetas_SDT.gxTpr_Tretiquetas_id});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("TrEtiquetas") ;
         /* End optimized UPDATE. */
      }

      protected void S131( )
      {
         /* 'ELIMINARETIQUETA' Routine */
      }

      protected void S141( )
      {
         /* 'AGREGARETIQUETA' Routine */
         /*
            INSERT RECORD ON TABLE TrTareasEtiquetas

         */
         A52TrTareasEtiquetas_TareaID = AV8GestionEtiquetas_SDT.gxTpr_Tretiquetas_idtarea;
         A53TrTareasEtiquetas_IDEtiqueta = AV8GestionEtiquetas_SDT.gxTpr_Tretiquetas_id;
         /* Using cursor P002N4 */
         pr_default.execute(2, new Object[] {A52TrTareasEtiquetas_TareaID, A53TrTareasEtiquetas_IDEtiqueta});
         A51TrTareasEtiquetas_ID = P002N4_A51TrTareasEtiquetas_ID[0];
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("TrTareasEtiquetas") ;
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
         A42TrEtiquetas_Nombre = "";
         A43TrEtiquetas_FechaCreacion = DateTime.MinValue;
         P002N2_A41TrEtiquetas_ID = new long[1] ;
         Gx_emsg = "";
         P002N4_A51TrTareasEtiquetas_ID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prgestionaretiquetas__default(),
            new Object[][] {
                new Object[] {
               P002N2_A41TrEtiquetas_ID
               }
               , new Object[] {
               }
               , new Object[] {
               P002N4_A51TrTareasEtiquetas_ID
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A45TrEtiquetas_Estado ;
      private int GX_INS6 ;
      private int GX_INS8 ;
      private long A40TrEtiquetas_IDTarea ;
      private long A41TrEtiquetas_ID ;
      private long A52TrTareasEtiquetas_TareaID ;
      private long A53TrTareasEtiquetas_IDEtiqueta ;
      private long A51TrTareasEtiquetas_ID ;
      private String AV9Modo ;
      private String A42TrEtiquetas_Nombre ;
      private String Gx_emsg ;
      private DateTime A43TrEtiquetas_FechaCreacion ;
      private bool returnInSub ;
      private bool n40TrEtiquetas_IDTarea ;
      private bool n42TrEtiquetas_Nombre ;
      private bool n43TrEtiquetas_FechaCreacion ;
      private bool n45TrEtiquetas_Estado ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002N2_A41TrEtiquetas_ID ;
      private long[] P002N4_A51TrTareasEtiquetas_ID ;
      private SdtGestionEtiquetas_SDT AV8GestionEtiquetas_SDT ;
   }

   public class prgestionaretiquetas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002N2 ;
          prmP002N2 = new Object[] {
          new Object[] {"@TrEtiquetas_Nombre",SqlDbType.NChar,256,0} ,
          new Object[] {"@TrEtiquetas_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrEtiquetas_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrEtiquetas_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmP002N3 ;
          prmP002N3 = new Object[] {
          new Object[] {"@TrEtiquetas_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrEtiquetas_Nombre",SqlDbType.NChar,256,0} ,
          new Object[] {"@AV8Gesti_1Tretiquetas_id",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmP002N4 ;
          prmP002N4 = new Object[] {
          new Object[] {"@TrTareasEtiquetas_TareaID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrTareasEtiquetas_IDEtiqueta",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P002N2", "INSERT INTO TABLERO.[TrEtiquetas]([TrEtiquetas_Nombre], [TrEtiquetas_FechaCreacion], [TrEtiquetas_Estado], [TrEtiquetas_IDTarea], [TrEtiquetas_FechaModificacion]) VALUES(@TrEtiquetas_Nombre, @TrEtiquetas_FechaCreacion, @TrEtiquetas_Estado, @TrEtiquetas_IDTarea, convert( DATETIME, '17530101', 112 )); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP002N2)
             ,new CursorDef("P002N3", "UPDATE TABLERO.[TrEtiquetas] SET [TrEtiquetas_FechaModificacion]=GETUTCDATE(), [TrEtiquetas_Estado]=@TrEtiquetas_Estado, [TrEtiquetas_Nombre]=@TrEtiquetas_Nombre  WHERE [TrEtiquetas_ID] = @AV8Gesti_1Tretiquetas_id", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP002N3)
             ,new CursorDef("P002N4", "INSERT INTO TABLERO.[TrTareasEtiquetas]([TrTareasEtiquetas_TareaID], [TrTareasEtiquetas_IDEtiqueta]) VALUES(@TrTareasEtiquetas_TareaID, @TrTareasEtiquetas_IDEtiqueta); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP002N4)
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
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(1, (String)parms[1]);
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
                   stmt.setNull( 3 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(3, (short)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(4, (long)parms[7]);
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
                   stmt.setNull( 2 , SqlDbType.NChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[3]);
                }
                stmt.SetParameter(3, (long)parms[4]);
                return;
             case 2 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                return;
       }
    }

 }

}
