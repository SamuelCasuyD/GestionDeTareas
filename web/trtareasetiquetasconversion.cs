using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class trtareasetiquetasconversion : GXProcedure
   {
      public trtareasetiquetasconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public trtareasetiquetasconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         trtareasetiquetasconversion objtrtareasetiquetasconversion;
         objtrtareasetiquetasconversion = new trtareasetiquetasconversion();
         objtrtareasetiquetasconversion.context.SetSubmitInitialConfig(context);
         objtrtareasetiquetasconversion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtrtareasetiquetasconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((trtareasetiquetasconversion)stateInfo).executePrivate();
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
         cmdBuffer=" SET IDENTITY_INSERT TABLERO.[GXA0008] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor TRTAREASET2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A49TrTareasEtiquetas_IDTarea = TRTAREASET2_A49TrTareasEtiquetas_IDTarea[0];
            A51TrTareasEtiquetas_ID = TRTAREASET2_A51TrTareasEtiquetas_ID[0];
            /*
               INSERT RECORD ON TABLE GXA0008

            */
            AV2TrTareasEtiquetas_ID = A51TrTareasEtiquetas_ID;
            AV3TrTareasEtiquetas_IDTarea = A49TrTareasEtiquetas_IDTarea;
            if ( (0==A12TrGestionTareas_ID) )
            {
               AV4TrTareasEtiquetas_TareaID = 0;
            }
            else
            {
               AV4TrTareasEtiquetas_TareaID = A12TrGestionTareas_ID;
            }
            /* Using cursor TRTAREASET3 */
            pr_default.execute(1, new Object[] {AV2TrTareasEtiquetas_ID, AV3TrTareasEtiquetas_IDTarea, AV4TrTareasEtiquetas_TareaID});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("GXA0008") ;
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (String)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cmdBuffer=" SET IDENTITY_INSERT TABLERO.[GXA0008] OFF "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         this.cleanup();
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
         cmdBuffer = "";
         scmdbuf = "";
         TRTAREASET2_A49TrTareasEtiquetas_IDTarea = new long[1] ;
         TRTAREASET2_A51TrTareasEtiquetas_ID = new long[1] ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trtareasetiquetasconversion__default(),
            new Object[][] {
                new Object[] {
               TRTAREASET2_A49TrTareasEtiquetas_IDTarea, TRTAREASET2_A51TrTareasEtiquetas_ID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int GIGXA0008 ;
      private long A49TrTareasEtiquetas_IDTarea ;
      private long A51TrTareasEtiquetas_ID ;
      private long AV2TrTareasEtiquetas_ID ;
      private long AV3TrTareasEtiquetas_IDTarea ;
      private long A12TrGestionTareas_ID ;
      private long AV4TrTareasEtiquetas_TareaID ;
      private String cmdBuffer ;
      private String scmdbuf ;
      private String Gx_emsg ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
      private long[] TRTAREASET2_A49TrTareasEtiquetas_IDTarea ;
      private long[] TRTAREASET2_A51TrTareasEtiquetas_ID ;
   }

   public class trtareasetiquetasconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTRTAREASET2 ;
          prmTRTAREASET2 = new Object[] {
          } ;
          Object[] prmTRTAREASET3 ;
          prmTRTAREASET3 = new Object[] {
          new Object[] {"@AV2TrTareasEtiquetas_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV3TrTareasEtiquetas_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV4TrTareasEtiquetas_TareaID",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("TRTAREASET2", "SELECT [TrTareasEtiquetas_IDTarea], [TrTareasEtiquetas_ID] FROM TABLERO.[TrTareasEtiquetas] ORDER BY [TrTareasEtiquetas_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTRTAREASET2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TRTAREASET3", "INSERT INTO TABLERO.[GXA0008]([TrTareasEtiquetas_ID], [TrTareasEtiquetas_IDTarea], [TrTareasEtiquetas_TareaID]) VALUES(@AV2TrTareasEtiquetas_ID, @AV3TrTareasEtiquetas_IDTarea, @AV4TrTareasEtiquetas_TareaID)", GxErrorMask.GX_NOMASK,prmTRTAREASET3)
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
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 1 :
                stmt.SetParameter(1, (long)parms[0]);
                stmt.SetParameter(2, (long)parms[1]);
                stmt.SetParameter(3, (long)parms[2]);
                return;
       }
    }

 }

}
