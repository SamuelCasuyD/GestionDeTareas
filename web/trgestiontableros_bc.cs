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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trgestiontableros_bc : GXHttpHandler, IGxSilentTrn
   {
      public trgestiontableros_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public trgestiontableros_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            /* Execute user event: After Trn */
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
               SetMode( "UPD") ;
            }
         }
      }

      public override String ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
      }

      protected void E11012( )
      {
         /* After Trn Routine */
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z2TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
            Z9TrGestionTableros_TipoTablero = A9TrGestionTableros_TipoTablero;
            Z3TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
            Z4TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
            Z7TrGestionTableros_FechaCreacion = A7TrGestionTableros_FechaCreacion;
            Z8TrGestionTableros_FechaModificacion = A8TrGestionTableros_FechaModificacion;
            Z10TrGestionTableros_Estado = A10TrGestionTableros_Estado;
         }
         if ( GX_JID == -9 )
         {
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
            Z2TrGestionTableros_Nombre = A2TrGestionTableros_Nombre;
            Z6TrGestionTableros_Comentario = A6TrGestionTableros_Comentario;
            Z5TrGestionTableros_Descripcion = A5TrGestionTableros_Descripcion;
            Z9TrGestionTableros_TipoTablero = A9TrGestionTableros_TipoTablero;
            Z3TrGestionTableros_FechaInicio = A3TrGestionTableros_FechaInicio;
            Z4TrGestionTableros_FechaFin = A4TrGestionTableros_FechaFin;
            Z7TrGestionTableros_FechaCreacion = A7TrGestionTableros_FechaCreacion;
            Z8TrGestionTableros_FechaModificacion = A8TrGestionTableros_FechaModificacion;
            Z10TrGestionTableros_Estado = A10TrGestionTableros_Estado;
         }
      }

      protected void standaloneNotModal( )
      {
         AV7GUID = (Guid)(Guid.NewGuid( ));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A1TrGestionTableros_ID = (Guid)(AV7GUID);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A2TrGestionTableros_Nombre = BC00014_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = BC00014_n2TrGestionTableros_Nombre[0];
            A6TrGestionTableros_Comentario = BC00014_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = BC00014_n6TrGestionTableros_Comentario[0];
            A5TrGestionTableros_Descripcion = BC00014_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = BC00014_n5TrGestionTableros_Descripcion[0];
            A9TrGestionTableros_TipoTablero = BC00014_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = BC00014_n9TrGestionTableros_TipoTablero[0];
            A3TrGestionTableros_FechaInicio = BC00014_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = BC00014_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = BC00014_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = BC00014_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = BC00014_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = BC00014_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = BC00014_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = BC00014_n8TrGestionTableros_FechaModificacion[0];
            A10TrGestionTableros_Estado = BC00014_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = BC00014_n10TrGestionTableros_Estado[0];
            ZM011( -9) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A3TrGestionTableros_FechaInicio) || ( A3TrGestionTableros_FechaInicio >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Fecha Inicio is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A4TrGestionTableros_FechaFin) || ( A4TrGestionTableros_FechaFin >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Fecha Fin is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A7TrGestionTableros_FechaCreacion) || ( A7TrGestionTableros_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Fecha Creacion del tablero is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A8TrGestionTableros_FechaModificacion) || ( A8TrGestionTableros_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Fecha Modificacion del tablero is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A10TrGestionTableros_Estado == 1 ) || ( A10TrGestionTableros_Estado == 2 ) || ( A10TrGestionTableros_Estado == 3 ) || ( A10TrGestionTableros_Estado == 4 ) || ( A10TrGestionTableros_Estado == 5 ) || (0==A10TrGestionTableros_Estado) ) )
         {
            GX_msglist.addItem("Field Estado del tablero is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1TrGestionTableros_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 9) ;
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(BC00013_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = BC00013_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = BC00013_n2TrGestionTableros_Nombre[0];
            A6TrGestionTableros_Comentario = BC00013_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = BC00013_n6TrGestionTableros_Comentario[0];
            A5TrGestionTableros_Descripcion = BC00013_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = BC00013_n5TrGestionTableros_Descripcion[0];
            A9TrGestionTableros_TipoTablero = BC00013_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = BC00013_n9TrGestionTableros_TipoTablero[0];
            A3TrGestionTableros_FechaInicio = BC00013_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = BC00013_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = BC00013_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = BC00013_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = BC00013_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = BC00013_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = BC00013_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = BC00013_n8TrGestionTableros_FechaModificacion[0];
            A10TrGestionTableros_Estado = BC00013_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = BC00013_n10TrGestionTableros_Estado[0];
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_010( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1TrGestionTableros_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrGestionTableros"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2TrGestionTableros_Nombre, BC00012_A2TrGestionTableros_Nombre[0]) != 0 ) || ( Z9TrGestionTableros_TipoTablero != BC00012_A9TrGestionTableros_TipoTablero[0] ) || ( Z3TrGestionTableros_FechaInicio != BC00012_A3TrGestionTableros_FechaInicio[0] ) || ( Z4TrGestionTableros_FechaFin != BC00012_A4TrGestionTableros_FechaFin[0] ) || ( Z7TrGestionTableros_FechaCreacion != BC00012_A7TrGestionTableros_FechaCreacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z8TrGestionTableros_FechaModificacion != BC00012_A8TrGestionTableros_FechaModificacion[0] ) || ( Z10TrGestionTableros_Estado != BC00012_A10TrGestionTableros_Estado[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrGestionTableros"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00016 */
                     pr_default.execute(4, new Object[] {A1TrGestionTableros_ID, n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion, n9TrGestionTableros_TipoTablero, A9TrGestionTableros_TipoTablero, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n8TrGestionTableros_FechaModificacion, A8TrGestionTableros_FechaModificacion, n10TrGestionTableros_Estado, A10TrGestionTableros_Estado});
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {n2TrGestionTableros_Nombre, A2TrGestionTableros_Nombre, n6TrGestionTableros_Comentario, A6TrGestionTableros_Comentario, n5TrGestionTableros_Descripcion, A5TrGestionTableros_Descripcion, n9TrGestionTableros_TipoTablero, A9TrGestionTableros_TipoTablero, n3TrGestionTableros_FechaInicio, A3TrGestionTableros_FechaInicio, n4TrGestionTableros_FechaFin, A4TrGestionTableros_FechaFin, n7TrGestionTableros_FechaCreacion, A7TrGestionTableros_FechaCreacion, n8TrGestionTableros_FechaModificacion, A8TrGestionTableros_FechaModificacion, n10TrGestionTableros_Estado, A10TrGestionTableros_Estado, A1TrGestionTableros_ID});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrGestionTableros"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00018 */
                  pr_default.execute(6, new Object[] {A1TrGestionTableros_ID});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("TrGestionTableros") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_sucdeleted", ""), "SuccessfullyDeleted", 0, "", true);
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00019 */
            pr_default.execute(7, new Object[] {A1TrGestionTableros_ID});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tr Gestion Tareas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart011( )
      {
         /* Using cursor BC000110 */
         pr_default.execute(8, new Object[] {A1TrGestionTableros_ID});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(BC000110_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = BC000110_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = BC000110_n2TrGestionTableros_Nombre[0];
            A6TrGestionTableros_Comentario = BC000110_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = BC000110_n6TrGestionTableros_Comentario[0];
            A5TrGestionTableros_Descripcion = BC000110_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = BC000110_n5TrGestionTableros_Descripcion[0];
            A9TrGestionTableros_TipoTablero = BC000110_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = BC000110_n9TrGestionTableros_TipoTablero[0];
            A3TrGestionTableros_FechaInicio = BC000110_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = BC000110_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = BC000110_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = BC000110_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = BC000110_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = BC000110_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = BC000110_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = BC000110_n8TrGestionTableros_FechaModificacion[0];
            A10TrGestionTableros_Estado = BC000110_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = BC000110_n10TrGestionTableros_Estado[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound1 = 1;
            A1TrGestionTableros_ID = (Guid)((Guid)(BC000110_A1TrGestionTableros_ID[0]));
            A2TrGestionTableros_Nombre = BC000110_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = BC000110_n2TrGestionTableros_Nombre[0];
            A6TrGestionTableros_Comentario = BC000110_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = BC000110_n6TrGestionTableros_Comentario[0];
            A5TrGestionTableros_Descripcion = BC000110_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = BC000110_n5TrGestionTableros_Descripcion[0];
            A9TrGestionTableros_TipoTablero = BC000110_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = BC000110_n9TrGestionTableros_TipoTablero[0];
            A3TrGestionTableros_FechaInicio = BC000110_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = BC000110_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = BC000110_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = BC000110_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = BC000110_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = BC000110_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = BC000110_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = BC000110_n8TrGestionTableros_FechaModificacion[0];
            A10TrGestionTableros_Estado = BC000110_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = BC000110_n10TrGestionTableros_Estado[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcTrGestionTableros) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcTrGestionTableros, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A2TrGestionTableros_Nombre = "";
         n2TrGestionTableros_Nombre = false;
         A6TrGestionTableros_Comentario = "";
         n6TrGestionTableros_Comentario = false;
         A5TrGestionTableros_Descripcion = "";
         n5TrGestionTableros_Descripcion = false;
         A9TrGestionTableros_TipoTablero = 0;
         n9TrGestionTableros_TipoTablero = false;
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         n3TrGestionTableros_FechaInicio = false;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         n4TrGestionTableros_FechaFin = false;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         n7TrGestionTableros_FechaCreacion = false;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         n8TrGestionTableros_FechaModificacion = false;
         A10TrGestionTableros_Estado = 0;
         n10TrGestionTableros_Estado = false;
         Z2TrGestionTableros_Nombre = "";
         Z9TrGestionTableros_TipoTablero = 0;
         Z3TrGestionTableros_FechaInicio = DateTime.MinValue;
         Z4TrGestionTableros_FechaFin = DateTime.MinValue;
         Z7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         Z8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         Z10TrGestionTableros_Estado = 0;
      }

      protected void InitAll011( )
      {
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow1( SdtTrGestionTableros obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Trgestiontableros_nombre = A2TrGestionTableros_Nombre;
         obj1.gxTpr_Trgestiontableros_comentario = A6TrGestionTableros_Comentario;
         obj1.gxTpr_Trgestiontableros_descripcion = A5TrGestionTableros_Descripcion;
         obj1.gxTpr_Trgestiontableros_tipotablero = A9TrGestionTableros_TipoTablero;
         obj1.gxTpr_Trgestiontableros_fechainicio = A3TrGestionTableros_FechaInicio;
         obj1.gxTpr_Trgestiontableros_fechafin = A4TrGestionTableros_FechaFin;
         obj1.gxTpr_Trgestiontableros_fechacreacion = A7TrGestionTableros_FechaCreacion;
         obj1.gxTpr_Trgestiontableros_fechamodificacion = A8TrGestionTableros_FechaModificacion;
         obj1.gxTpr_Trgestiontableros_estado = A10TrGestionTableros_Estado;
         obj1.gxTpr_Trgestiontableros_id = (Guid)(A1TrGestionTableros_ID);
         obj1.gxTpr_Trgestiontableros_id_Z = (Guid)(Z1TrGestionTableros_ID);
         obj1.gxTpr_Trgestiontableros_nombre_Z = Z2TrGestionTableros_Nombre;
         obj1.gxTpr_Trgestiontableros_tipotablero_Z = Z9TrGestionTableros_TipoTablero;
         obj1.gxTpr_Trgestiontableros_fechainicio_Z = Z3TrGestionTableros_FechaInicio;
         obj1.gxTpr_Trgestiontableros_fechafin_Z = Z4TrGestionTableros_FechaFin;
         obj1.gxTpr_Trgestiontableros_fechacreacion_Z = Z7TrGestionTableros_FechaCreacion;
         obj1.gxTpr_Trgestiontableros_fechamodificacion_Z = Z8TrGestionTableros_FechaModificacion;
         obj1.gxTpr_Trgestiontableros_estado_Z = Z10TrGestionTableros_Estado;
         obj1.gxTpr_Trgestiontableros_nombre_N = (short)(Convert.ToInt16(n2TrGestionTableros_Nombre));
         obj1.gxTpr_Trgestiontableros_comentario_N = (short)(Convert.ToInt16(n6TrGestionTableros_Comentario));
         obj1.gxTpr_Trgestiontableros_descripcion_N = (short)(Convert.ToInt16(n5TrGestionTableros_Descripcion));
         obj1.gxTpr_Trgestiontableros_tipotablero_N = (short)(Convert.ToInt16(n9TrGestionTableros_TipoTablero));
         obj1.gxTpr_Trgestiontableros_fechainicio_N = (short)(Convert.ToInt16(n3TrGestionTableros_FechaInicio));
         obj1.gxTpr_Trgestiontableros_fechafin_N = (short)(Convert.ToInt16(n4TrGestionTableros_FechaFin));
         obj1.gxTpr_Trgestiontableros_fechacreacion_N = (short)(Convert.ToInt16(n7TrGestionTableros_FechaCreacion));
         obj1.gxTpr_Trgestiontableros_fechamodificacion_N = (short)(Convert.ToInt16(n8TrGestionTableros_FechaModificacion));
         obj1.gxTpr_Trgestiontableros_estado_N = (short)(Convert.ToInt16(n10TrGestionTableros_Estado));
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtTrGestionTableros obj1 )
      {
         obj1.gxTpr_Trgestiontableros_id = (Guid)(A1TrGestionTableros_ID);
         return  ;
      }

      public void RowToVars1( SdtTrGestionTableros obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A2TrGestionTableros_Nombre = obj1.gxTpr_Trgestiontableros_nombre;
         n2TrGestionTableros_Nombre = false;
         A6TrGestionTableros_Comentario = obj1.gxTpr_Trgestiontableros_comentario;
         n6TrGestionTableros_Comentario = false;
         A5TrGestionTableros_Descripcion = obj1.gxTpr_Trgestiontableros_descripcion;
         n5TrGestionTableros_Descripcion = false;
         A9TrGestionTableros_TipoTablero = obj1.gxTpr_Trgestiontableros_tipotablero;
         n9TrGestionTableros_TipoTablero = false;
         A3TrGestionTableros_FechaInicio = obj1.gxTpr_Trgestiontableros_fechainicio;
         n3TrGestionTableros_FechaInicio = false;
         A4TrGestionTableros_FechaFin = obj1.gxTpr_Trgestiontableros_fechafin;
         n4TrGestionTableros_FechaFin = false;
         A7TrGestionTableros_FechaCreacion = obj1.gxTpr_Trgestiontableros_fechacreacion;
         n7TrGestionTableros_FechaCreacion = false;
         A8TrGestionTableros_FechaModificacion = obj1.gxTpr_Trgestiontableros_fechamodificacion;
         n8TrGestionTableros_FechaModificacion = false;
         A10TrGestionTableros_Estado = obj1.gxTpr_Trgestiontableros_estado;
         n10TrGestionTableros_Estado = false;
         A1TrGestionTableros_ID = (Guid)(obj1.gxTpr_Trgestiontableros_id);
         Z1TrGestionTableros_ID = (Guid)(obj1.gxTpr_Trgestiontableros_id_Z);
         Z2TrGestionTableros_Nombre = obj1.gxTpr_Trgestiontableros_nombre_Z;
         Z9TrGestionTableros_TipoTablero = obj1.gxTpr_Trgestiontableros_tipotablero_Z;
         Z3TrGestionTableros_FechaInicio = obj1.gxTpr_Trgestiontableros_fechainicio_Z;
         Z4TrGestionTableros_FechaFin = obj1.gxTpr_Trgestiontableros_fechafin_Z;
         Z7TrGestionTableros_FechaCreacion = obj1.gxTpr_Trgestiontableros_fechacreacion_Z;
         Z8TrGestionTableros_FechaModificacion = obj1.gxTpr_Trgestiontableros_fechamodificacion_Z;
         Z10TrGestionTableros_Estado = obj1.gxTpr_Trgestiontableros_estado_Z;
         n2TrGestionTableros_Nombre = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_nombre_N));
         n6TrGestionTableros_Comentario = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_comentario_N));
         n5TrGestionTableros_Descripcion = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_descripcion_N));
         n9TrGestionTableros_TipoTablero = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_tipotablero_N));
         n3TrGestionTableros_FechaInicio = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_fechainicio_N));
         n4TrGestionTableros_FechaFin = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_fechafin_N));
         n7TrGestionTableros_FechaCreacion = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_fechacreacion_N));
         n8TrGestionTableros_FechaModificacion = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_fechamodificacion_N));
         n10TrGestionTableros_Estado = (bool)(Convert.ToBoolean(obj1.gxTpr_Trgestiontableros_estado_N));
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1TrGestionTableros_ID = (Guid)((Guid)getParm(obj,0));
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
         }
         ZM011( -9) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars1( bcTrGestionTableros, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1TrGestionTableros_ID = (Guid)(A1TrGestionTableros_ID);
         }
         ZM011( -9) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
               {
                  A1TrGestionTableros_ID = (Guid)(Z1TrGestionTableros_ID);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update011( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcTrGestionTableros, 0) ;
         SaveImpl( ) ;
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcTrGestionTableros, 0) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtTrGestionTableros auxBC = new SdtTrGestionTableros(context) ;
            IGxSilentTrn auxTrn = auxBC.getTransaction() ;
            auxBC.Load(A1TrGestionTableros_ID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrGestionTableros);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcTrGestionTableros, 0) ;
         UpdateImpl( ) ;
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcTrGestionTableros, 0) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcTrGestionTableros, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
            {
               A1TrGestionTableros_ID = (Guid)(Z1TrGestionTableros_ID);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A1TrGestionTableros_ID != Z1TrGestionTableros_ID )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("trgestiontableros_bc",pr_default);
         VarsToRow1( bcTrGestionTableros) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public String GetMode( )
      {
         Gx_mode = bcTrGestionTableros.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( String lMode )
      {
         Gx_mode = lMode;
         bcTrGestionTableros.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrGestionTableros )
         {
            bcTrGestionTableros = (SdtTrGestionTableros)(sdt);
            if ( StringUtil.StrCmp(bcTrGestionTableros.gxTpr_Mode, "") == 0 )
            {
               bcTrGestionTableros.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcTrGestionTableros) ;
            }
            else
            {
               RowToVars1( bcTrGestionTableros, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrGestionTableros.gxTpr_Mode, "") == 0 )
            {
               bcTrGestionTableros.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcTrGestionTableros, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTrGestionTableros TrGestionTableros_BC
      {
         get {
            return bcTrGestionTableros ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         Z1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         Z2TrGestionTableros_Nombre = "";
         A2TrGestionTableros_Nombre = "";
         Z3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         Z4TrGestionTableros_FechaFin = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         Z7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         Z8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         Z6TrGestionTableros_Comentario = "";
         A6TrGestionTableros_Comentario = "";
         Z5TrGestionTableros_Descripcion = "";
         A5TrGestionTableros_Descripcion = "";
         AV7GUID = (Guid)(Guid.Empty);
         BC00014_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC00014_A2TrGestionTableros_Nombre = new String[] {""} ;
         BC00014_n2TrGestionTableros_Nombre = new bool[] {false} ;
         BC00014_A6TrGestionTableros_Comentario = new String[] {""} ;
         BC00014_n6TrGestionTableros_Comentario = new bool[] {false} ;
         BC00014_A5TrGestionTableros_Descripcion = new String[] {""} ;
         BC00014_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         BC00014_A9TrGestionTableros_TipoTablero = new short[1] ;
         BC00014_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         BC00014_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00014_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         BC00014_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00014_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         BC00014_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00014_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         BC00014_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         BC00014_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         BC00014_A10TrGestionTableros_Estado = new short[1] ;
         BC00014_n10TrGestionTableros_Estado = new bool[] {false} ;
         BC00015_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC00013_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC00013_A2TrGestionTableros_Nombre = new String[] {""} ;
         BC00013_n2TrGestionTableros_Nombre = new bool[] {false} ;
         BC00013_A6TrGestionTableros_Comentario = new String[] {""} ;
         BC00013_n6TrGestionTableros_Comentario = new bool[] {false} ;
         BC00013_A5TrGestionTableros_Descripcion = new String[] {""} ;
         BC00013_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         BC00013_A9TrGestionTableros_TipoTablero = new short[1] ;
         BC00013_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         BC00013_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00013_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         BC00013_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00013_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         BC00013_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00013_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         BC00013_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         BC00013_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         BC00013_A10TrGestionTableros_Estado = new short[1] ;
         BC00013_n10TrGestionTableros_Estado = new bool[] {false} ;
         sMode1 = "";
         BC00012_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC00012_A2TrGestionTableros_Nombre = new String[] {""} ;
         BC00012_n2TrGestionTableros_Nombre = new bool[] {false} ;
         BC00012_A6TrGestionTableros_Comentario = new String[] {""} ;
         BC00012_n6TrGestionTableros_Comentario = new bool[] {false} ;
         BC00012_A5TrGestionTableros_Descripcion = new String[] {""} ;
         BC00012_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         BC00012_A9TrGestionTableros_TipoTablero = new short[1] ;
         BC00012_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         BC00012_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC00012_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         BC00012_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         BC00012_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         BC00012_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC00012_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         BC00012_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         BC00012_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         BC00012_A10TrGestionTableros_Estado = new short[1] ;
         BC00012_n10TrGestionTableros_Estado = new bool[] {false} ;
         BC00019_A12TrGestionTareas_ID = new long[1] ;
         BC000110_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         BC000110_A2TrGestionTableros_Nombre = new String[] {""} ;
         BC000110_n2TrGestionTableros_Nombre = new bool[] {false} ;
         BC000110_A6TrGestionTableros_Comentario = new String[] {""} ;
         BC000110_n6TrGestionTableros_Comentario = new bool[] {false} ;
         BC000110_A5TrGestionTableros_Descripcion = new String[] {""} ;
         BC000110_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         BC000110_A9TrGestionTableros_TipoTablero = new short[1] ;
         BC000110_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         BC000110_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         BC000110_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         BC000110_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         BC000110_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         BC000110_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         BC000110_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         BC000110_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         BC000110_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         BC000110_A10TrGestionTableros_Estado = new short[1] ;
         BC000110_n10TrGestionTableros_Estado = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trgestiontableros_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1TrGestionTableros_ID, BC00012_A2TrGestionTableros_Nombre, BC00012_n2TrGestionTableros_Nombre, BC00012_A6TrGestionTableros_Comentario, BC00012_n6TrGestionTableros_Comentario, BC00012_A5TrGestionTableros_Descripcion, BC00012_n5TrGestionTableros_Descripcion, BC00012_A9TrGestionTableros_TipoTablero, BC00012_n9TrGestionTableros_TipoTablero, BC00012_A3TrGestionTableros_FechaInicio,
               BC00012_n3TrGestionTableros_FechaInicio, BC00012_A4TrGestionTableros_FechaFin, BC00012_n4TrGestionTableros_FechaFin, BC00012_A7TrGestionTableros_FechaCreacion, BC00012_n7TrGestionTableros_FechaCreacion, BC00012_A8TrGestionTableros_FechaModificacion, BC00012_n8TrGestionTableros_FechaModificacion, BC00012_A10TrGestionTableros_Estado, BC00012_n10TrGestionTableros_Estado
               }
               , new Object[] {
               BC00013_A1TrGestionTableros_ID, BC00013_A2TrGestionTableros_Nombre, BC00013_n2TrGestionTableros_Nombre, BC00013_A6TrGestionTableros_Comentario, BC00013_n6TrGestionTableros_Comentario, BC00013_A5TrGestionTableros_Descripcion, BC00013_n5TrGestionTableros_Descripcion, BC00013_A9TrGestionTableros_TipoTablero, BC00013_n9TrGestionTableros_TipoTablero, BC00013_A3TrGestionTableros_FechaInicio,
               BC00013_n3TrGestionTableros_FechaInicio, BC00013_A4TrGestionTableros_FechaFin, BC00013_n4TrGestionTableros_FechaFin, BC00013_A7TrGestionTableros_FechaCreacion, BC00013_n7TrGestionTableros_FechaCreacion, BC00013_A8TrGestionTableros_FechaModificacion, BC00013_n8TrGestionTableros_FechaModificacion, BC00013_A10TrGestionTableros_Estado, BC00013_n10TrGestionTableros_Estado
               }
               , new Object[] {
               BC00014_A1TrGestionTableros_ID, BC00014_A2TrGestionTableros_Nombre, BC00014_n2TrGestionTableros_Nombre, BC00014_A6TrGestionTableros_Comentario, BC00014_n6TrGestionTableros_Comentario, BC00014_A5TrGestionTableros_Descripcion, BC00014_n5TrGestionTableros_Descripcion, BC00014_A9TrGestionTableros_TipoTablero, BC00014_n9TrGestionTableros_TipoTablero, BC00014_A3TrGestionTableros_FechaInicio,
               BC00014_n3TrGestionTableros_FechaInicio, BC00014_A4TrGestionTableros_FechaFin, BC00014_n4TrGestionTableros_FechaFin, BC00014_A7TrGestionTableros_FechaCreacion, BC00014_n7TrGestionTableros_FechaCreacion, BC00014_A8TrGestionTableros_FechaModificacion, BC00014_n8TrGestionTableros_FechaModificacion, BC00014_A10TrGestionTableros_Estado, BC00014_n10TrGestionTableros_Estado
               }
               , new Object[] {
               BC00015_A1TrGestionTableros_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00019_A12TrGestionTareas_ID
               }
               , new Object[] {
               BC000110_A1TrGestionTableros_ID, BC000110_A2TrGestionTableros_Nombre, BC000110_n2TrGestionTableros_Nombre, BC000110_A6TrGestionTableros_Comentario, BC000110_n6TrGestionTableros_Comentario, BC000110_A5TrGestionTableros_Descripcion, BC000110_n5TrGestionTableros_Descripcion, BC000110_A9TrGestionTableros_TipoTablero, BC000110_n9TrGestionTableros_TipoTablero, BC000110_A3TrGestionTableros_FechaInicio,
               BC000110_n3TrGestionTableros_FechaInicio, BC000110_A4TrGestionTableros_FechaFin, BC000110_n4TrGestionTableros_FechaFin, BC000110_A7TrGestionTableros_FechaCreacion, BC000110_n7TrGestionTableros_FechaCreacion, BC000110_A8TrGestionTableros_FechaModificacion, BC000110_n8TrGestionTableros_FechaModificacion, BC000110_A10TrGestionTableros_Estado, BC000110_n10TrGestionTableros_Estado
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z9TrGestionTableros_TipoTablero ;
      private short A9TrGestionTableros_TipoTablero ;
      private short Z10TrGestionTableros_Estado ;
      private short A10TrGestionTableros_Estado ;
      private short Gx_BScreen ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private int trnEnded ;
      private String scmdbuf ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String Gx_mode ;
      private String Z2TrGestionTableros_Nombre ;
      private String A2TrGestionTableros_Nombre ;
      private String sMode1 ;
      private DateTime Z3TrGestionTableros_FechaInicio ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime Z4TrGestionTableros_FechaFin ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime Z7TrGestionTableros_FechaCreacion ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private DateTime Z8TrGestionTableros_FechaModificacion ;
      private DateTime A8TrGestionTableros_FechaModificacion ;
      private bool n2TrGestionTableros_Nombre ;
      private bool n6TrGestionTableros_Comentario ;
      private bool n5TrGestionTableros_Descripcion ;
      private bool n9TrGestionTableros_TipoTablero ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n8TrGestionTableros_FechaModificacion ;
      private bool n10TrGestionTableros_Estado ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private String Z6TrGestionTableros_Comentario ;
      private String A6TrGestionTableros_Comentario ;
      private String Z5TrGestionTableros_Descripcion ;
      private String A5TrGestionTableros_Descripcion ;
      private Guid Z1TrGestionTableros_ID ;
      private Guid A1TrGestionTableros_ID ;
      private Guid AV7GUID ;
      private SdtTrGestionTableros bcTrGestionTableros ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00014_A1TrGestionTableros_ID ;
      private String[] BC00014_A2TrGestionTableros_Nombre ;
      private bool[] BC00014_n2TrGestionTableros_Nombre ;
      private String[] BC00014_A6TrGestionTableros_Comentario ;
      private bool[] BC00014_n6TrGestionTableros_Comentario ;
      private String[] BC00014_A5TrGestionTableros_Descripcion ;
      private bool[] BC00014_n5TrGestionTableros_Descripcion ;
      private short[] BC00014_A9TrGestionTableros_TipoTablero ;
      private bool[] BC00014_n9TrGestionTableros_TipoTablero ;
      private DateTime[] BC00014_A3TrGestionTableros_FechaInicio ;
      private bool[] BC00014_n3TrGestionTableros_FechaInicio ;
      private DateTime[] BC00014_A4TrGestionTableros_FechaFin ;
      private bool[] BC00014_n4TrGestionTableros_FechaFin ;
      private DateTime[] BC00014_A7TrGestionTableros_FechaCreacion ;
      private bool[] BC00014_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] BC00014_A8TrGestionTableros_FechaModificacion ;
      private bool[] BC00014_n8TrGestionTableros_FechaModificacion ;
      private short[] BC00014_A10TrGestionTableros_Estado ;
      private bool[] BC00014_n10TrGestionTableros_Estado ;
      private Guid[] BC00015_A1TrGestionTableros_ID ;
      private Guid[] BC00013_A1TrGestionTableros_ID ;
      private String[] BC00013_A2TrGestionTableros_Nombre ;
      private bool[] BC00013_n2TrGestionTableros_Nombre ;
      private String[] BC00013_A6TrGestionTableros_Comentario ;
      private bool[] BC00013_n6TrGestionTableros_Comentario ;
      private String[] BC00013_A5TrGestionTableros_Descripcion ;
      private bool[] BC00013_n5TrGestionTableros_Descripcion ;
      private short[] BC00013_A9TrGestionTableros_TipoTablero ;
      private bool[] BC00013_n9TrGestionTableros_TipoTablero ;
      private DateTime[] BC00013_A3TrGestionTableros_FechaInicio ;
      private bool[] BC00013_n3TrGestionTableros_FechaInicio ;
      private DateTime[] BC00013_A4TrGestionTableros_FechaFin ;
      private bool[] BC00013_n4TrGestionTableros_FechaFin ;
      private DateTime[] BC00013_A7TrGestionTableros_FechaCreacion ;
      private bool[] BC00013_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] BC00013_A8TrGestionTableros_FechaModificacion ;
      private bool[] BC00013_n8TrGestionTableros_FechaModificacion ;
      private short[] BC00013_A10TrGestionTableros_Estado ;
      private bool[] BC00013_n10TrGestionTableros_Estado ;
      private Guid[] BC00012_A1TrGestionTableros_ID ;
      private String[] BC00012_A2TrGestionTableros_Nombre ;
      private bool[] BC00012_n2TrGestionTableros_Nombre ;
      private String[] BC00012_A6TrGestionTableros_Comentario ;
      private bool[] BC00012_n6TrGestionTableros_Comentario ;
      private String[] BC00012_A5TrGestionTableros_Descripcion ;
      private bool[] BC00012_n5TrGestionTableros_Descripcion ;
      private short[] BC00012_A9TrGestionTableros_TipoTablero ;
      private bool[] BC00012_n9TrGestionTableros_TipoTablero ;
      private DateTime[] BC00012_A3TrGestionTableros_FechaInicio ;
      private bool[] BC00012_n3TrGestionTableros_FechaInicio ;
      private DateTime[] BC00012_A4TrGestionTableros_FechaFin ;
      private bool[] BC00012_n4TrGestionTableros_FechaFin ;
      private DateTime[] BC00012_A7TrGestionTableros_FechaCreacion ;
      private bool[] BC00012_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] BC00012_A8TrGestionTableros_FechaModificacion ;
      private bool[] BC00012_n8TrGestionTableros_FechaModificacion ;
      private short[] BC00012_A10TrGestionTableros_Estado ;
      private bool[] BC00012_n10TrGestionTableros_Estado ;
      private long[] BC00019_A12TrGestionTareas_ID ;
      private Guid[] BC000110_A1TrGestionTableros_ID ;
      private String[] BC000110_A2TrGestionTableros_Nombre ;
      private bool[] BC000110_n2TrGestionTableros_Nombre ;
      private String[] BC000110_A6TrGestionTableros_Comentario ;
      private bool[] BC000110_n6TrGestionTableros_Comentario ;
      private String[] BC000110_A5TrGestionTableros_Descripcion ;
      private bool[] BC000110_n5TrGestionTableros_Descripcion ;
      private short[] BC000110_A9TrGestionTableros_TipoTablero ;
      private bool[] BC000110_n9TrGestionTableros_TipoTablero ;
      private DateTime[] BC000110_A3TrGestionTableros_FechaInicio ;
      private bool[] BC000110_n3TrGestionTableros_FechaInicio ;
      private DateTime[] BC000110_A4TrGestionTableros_FechaFin ;
      private bool[] BC000110_n4TrGestionTableros_FechaFin ;
      private DateTime[] BC000110_A7TrGestionTableros_FechaCreacion ;
      private bool[] BC000110_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] BC000110_A8TrGestionTableros_FechaModificacion ;
      private bool[] BC000110_n8TrGestionTableros_FechaModificacion ;
      private short[] BC000110_A10TrGestionTableros_Estado ;
      private bool[] BC000110_n10TrGestionTableros_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class trgestiontableros_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00014 ;
          prmBC00014 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00015 ;
          prmBC00015 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00013 ;
          prmBC00013 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00012 ;
          prmBC00012 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00016 ;
          prmBC00016 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_Estado",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmBC00017 ;
          prmBC00017 = new Object[] {
          new Object[] {"@TrGestionTableros_Nombre",SqlDbType.NChar,100,0} ,
          new Object[] {"@TrGestionTableros_Comentario",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrGestionTableros_TipoTablero",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrGestionTableros_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00018 ;
          prmBC00018 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC00019 ;
          prmBC00019 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          Object[] prmBC000110 ;
          prmBC000110 = new Object[] {
          new Object[] {"@TrGestionTableros_ID",SqlDbType.UniqueIdentifier,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] WITH (UPDLOCK) WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT TM1.[TrGestionTableros_ID], TM1.[TrGestionTableros_Nombre], TM1.[TrGestionTableros_Comentario], TM1.[TrGestionTableros_Descripcion], TM1.[TrGestionTableros_TipoTablero], TM1.[TrGestionTableros_FechaInicio], TM1.[TrGestionTableros_FechaFin], TM1.[TrGestionTableros_FechaCreacion], TM1.[TrGestionTableros_FechaModificacion], TM1.[TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] TM1 WHERE TM1.[TrGestionTableros_ID] = @TrGestionTableros_ID ORDER BY TM1.[TrGestionTableros_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros] WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "INSERT INTO TABLERO.[TrGestionTableros]([TrGestionTableros_ID], [TrGestionTableros_Nombre], [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado]) VALUES(@TrGestionTableros_ID, @TrGestionTableros_Nombre, @TrGestionTableros_Comentario, @TrGestionTableros_Descripcion, @TrGestionTableros_TipoTablero, @TrGestionTableros_FechaInicio, @TrGestionTableros_FechaFin, @TrGestionTableros_FechaCreacion, @TrGestionTableros_FechaModificacion, @TrGestionTableros_Estado)", GxErrorMask.GX_NOMASK,prmBC00016)
             ,new CursorDef("BC00017", "UPDATE TABLERO.[TrGestionTableros] SET [TrGestionTableros_Nombre]=@TrGestionTableros_Nombre, [TrGestionTableros_Comentario]=@TrGestionTableros_Comentario, [TrGestionTableros_Descripcion]=@TrGestionTableros_Descripcion, [TrGestionTableros_TipoTablero]=@TrGestionTableros_TipoTablero, [TrGestionTableros_FechaInicio]=@TrGestionTableros_FechaInicio, [TrGestionTableros_FechaFin]=@TrGestionTableros_FechaFin, [TrGestionTableros_FechaCreacion]=@TrGestionTableros_FechaCreacion, [TrGestionTableros_FechaModificacion]=@TrGestionTableros_FechaModificacion, [TrGestionTableros_Estado]=@TrGestionTableros_Estado  WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID", GxErrorMask.GX_NOMASK,prmBC00017)
             ,new CursorDef("BC00018", "DELETE FROM TABLERO.[TrGestionTableros]  WHERE [TrGestionTableros_ID] = @TrGestionTableros_ID", GxErrorMask.GX_NOMASK,prmBC00018)
             ,new CursorDef("BC00019", "SELECT TOP 1 [TrGestionTareas_ID] FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_IDTablero] = @TrGestionTableros_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00019,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000110", "SELECT TM1.[TrGestionTableros_ID], TM1.[TrGestionTableros_Nombre], TM1.[TrGestionTableros_Comentario], TM1.[TrGestionTableros_Descripcion], TM1.[TrGestionTableros_TipoTablero], TM1.[TrGestionTableros_FechaInicio], TM1.[TrGestionTableros_FechaFin], TM1.[TrGestionTableros_FechaCreacion], TM1.[TrGestionTableros_FechaModificacion], TM1.[TrGestionTableros_Estado] FROM TABLERO.[TrGestionTableros] TM1 WHERE TM1.[TrGestionTableros_ID] = @TrGestionTableros_ID ORDER BY TM1.[TrGestionTableros_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000110,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 8 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((String[]) buf[3])[0] = rslt.getLongVarchar(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((String[]) buf[5])[0] = rslt.getLongVarchar(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8) ;
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9) ;
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10) ;
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
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
             case 1 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 2 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 3 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 4 :
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
                   stmt.setNull( 4 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(4, (String)parms[6]);
                }
                if ( (bool)parms[7] )
                {
                   stmt.setNull( 5 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(5, (short)parms[8]);
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
                   stmt.setNull( 7 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(7, (DateTime)parms[12]);
                }
                if ( (bool)parms[13] )
                {
                   stmt.setNull( 8 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(8, (DateTime)parms[14]);
                }
                if ( (bool)parms[15] )
                {
                   stmt.setNull( 9 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(9, (DateTime)parms[16]);
                }
                if ( (bool)parms[17] )
                {
                   stmt.setNull( 10 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(10, (short)parms[18]);
                }
                return;
             case 5 :
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
                   stmt.setNull( 2 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(2, (String)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(3, (String)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(4, (short)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(5, (DateTime)parms[9]);
                }
                if ( (bool)parms[10] )
                {
                   stmt.setNull( 6 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(6, (DateTime)parms[11]);
                }
                if ( (bool)parms[12] )
                {
                   stmt.setNull( 7 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(7, (DateTime)parms[13]);
                }
                if ( (bool)parms[14] )
                {
                   stmt.setNull( 8 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(8, (DateTime)parms[15]);
                }
                if ( (bool)parms[16] )
                {
                   stmt.setNull( 9 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(9, (short)parms[17]);
                }
                stmt.SetParameter(10, (Guid)parms[18]);
                return;
             case 6 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 7 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
             case 8 :
                stmt.SetParameter(1, (Guid)parms[0]);
                return;
       }
    }

 }

}
