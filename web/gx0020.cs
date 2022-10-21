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
   public class gx0020 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0020( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public gx0020( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out long aP0_pTrGestionTareas_ID )
      {
         this.AV12pTrGestionTareas_ID = 0 ;
         executePrivate();
         aP0_pTrGestionTareas_ID=this.AV12pTrGestionTareas_ID;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCtrgestiontareas_estado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_84_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV6cTrGestionTareas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV7cTrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( GetNextPar( )));
               AV8cTrGestionTareas_FechaInicio = context.localUtil.ParseDateParm( GetNextPar( ));
               AV9cTrGestionTareas_FechaFin = context.localUtil.ParseDateParm( GetNextPar( ));
               AV10cTrGestionTareas_FechaCreacion = context.localUtil.ParseDateParm( GetNextPar( ));
               AV11cTrGestionTareas_FechaModificacion = context.localUtil.ParseDateParm( GetNextPar( ));
               AV14cTrGestionTareas_Estado = (short)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTareas_ID, AV7cTrGestionTareas_IDTablero, AV8cTrGestionTareas_FechaInicio, AV9cTrGestionTareas_FechaFin, AV10cTrGestionTareas_FechaCreacion, AV11cTrGestionTareas_FechaModificacion, AV14cTrGestionTareas_Estado) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV12pTrGestionTareas_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV12pTrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV12pTrGestionTareas_ID), 13, 0));
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA082( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START082( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202210202185955", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0020.aspx") + "?" + UrlEncode("" +AV12pTrGestionTareas_ID)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTAREAS_IDTABLERO", AV7cTrGestionTareas_IDTablero.ToString());
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTAREAS_FECHAINICIO", context.localUtil.Format(AV8cTrGestionTareas_FechaInicio, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTAREAS_FECHAFIN", context.localUtil.Format(AV9cTrGestionTareas_FechaFin, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTAREAS_FECHACREACION", context.localUtil.Format(AV10cTrGestionTareas_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTAREAS_FECHAMODIFICACION", context.localUtil.Format(AV11cTrGestionTareas_FechaModificacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRGESTIONTAREAS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cTrGestionTareas_Estado), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPTRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pTrGestionTareas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_IDFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontareas_idfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontareas_idtablerofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontareas_fechainiciofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAFINFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontareas_fechafinfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontareas_fechacreacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontareas_fechamodificacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divTrgestiontareas_estadofiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((String)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE082( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT082( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("gx0020.aspx") + "?" + UrlEncode("" +AV12pTrGestionTareas_ID) ;
      }

      public override String GetPgmname( )
      {
         return "Gx0020" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Tr Gestion Tareas" ;
      }

      protected void WB080( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrgestiontareas_idfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontareas_idfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontareas_idfilter_Internalname, "Tr Gestion Tareas_ID", "", "", lblLbltrgestiontareas_idfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontareas_id_Internalname, "Tr Gestion Tareas_ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontareas_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTrGestionTareas_ID), 13, 0, ".", "")), ((edtavCtrgestiontareas_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cTrGestionTareas_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cTrGestionTareas_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontareas_id_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrgestiontareas_id_Visible, edtavCtrgestiontareas_id_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrgestiontareas_idtablerofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontareas_idtablerofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontareas_idtablerofilter_Internalname, "Tr Gestion Tareas_IDTablero", "", "", lblLbltrgestiontareas_idtablerofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontareas_idtablero_Internalname, "Tr Gestion Tareas_IDTablero", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontareas_idtablero_Internalname, AV7cTrGestionTareas_IDTablero.ToString(), AV7cTrGestionTareas_IDTablero.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontareas_idtablero_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrgestiontareas_idtablero_Visible, edtavCtrgestiontareas_idtablero_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrgestiontareas_fechainiciofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontareas_fechainiciofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontareas_fechainiciofilter_Internalname, "Tr Gestion Tareas_Fecha Inicio", "", "", lblLbltrgestiontareas_fechainiciofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13081_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontareas_fechainicio_Internalname, "Tr Gestion Tareas_Fecha Inicio", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrgestiontareas_fechainicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontareas_fechainicio_Internalname, context.localUtil.Format(AV8cTrGestionTareas_FechaInicio, "99/99/9999"), context.localUtil.Format( AV8cTrGestionTareas_FechaInicio, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontareas_fechainicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrgestiontareas_fechainicio_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0020.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrgestiontareas_fechafinfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontareas_fechafinfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontareas_fechafinfilter_Internalname, "Tr Gestion Tareas_Fecha Fin", "", "", lblLbltrgestiontareas_fechafinfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14081_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontareas_fechafin_Internalname, "Tr Gestion Tareas_Fecha Fin", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrgestiontareas_fechafin_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontareas_fechafin_Internalname, context.localUtil.Format(AV9cTrGestionTareas_FechaFin, "99/99/9999"), context.localUtil.Format( AV9cTrGestionTareas_FechaFin, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontareas_fechafin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrgestiontareas_fechafin_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0020.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrgestiontareas_fechacreacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontareas_fechacreacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontareas_fechacreacionfilter_Internalname, "Tr Gestion Tareas_Fecha Creacion", "", "", lblLbltrgestiontareas_fechacreacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15081_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontareas_fechacreacion_Internalname, "Tr Gestion Tareas_Fecha Creacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrgestiontareas_fechacreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontareas_fechacreacion_Internalname, context.localUtil.Format(AV10cTrGestionTareas_FechaCreacion, "99/99/9999"), context.localUtil.Format( AV10cTrGestionTareas_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontareas_fechacreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrgestiontareas_fechacreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0020.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrgestiontareas_fechamodificacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontareas_fechamodificacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontareas_fechamodificacionfilter_Internalname, "Tr Gestion Tareas_Fecha Modificacion", "", "", lblLbltrgestiontareas_fechamodificacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16081_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrgestiontareas_fechamodificacion_Internalname, "Tr Gestion Tareas_Fecha Modificacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrgestiontareas_fechamodificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrgestiontareas_fechamodificacion_Internalname, context.localUtil.Format(AV11cTrGestionTareas_FechaModificacion, "99/99/9999"), context.localUtil.Format( AV11cTrGestionTareas_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrgestiontareas_fechamodificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrgestiontareas_fechamodificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0020.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrgestiontareas_estadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrgestiontareas_estadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrgestiontareas_estadofilter_Internalname, "Tr Gestion Tareas_Estado", "", "", lblLbltrgestiontareas_estadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCtrgestiontareas_estado_Internalname, "Tr Gestion Tareas_Estado", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCtrgestiontareas_estado, cmbavCtrgestiontareas_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV14cTrGestionTareas_Estado), 4, 0)), 1, cmbavCtrgestiontareas_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCtrgestiontareas_estado.Visible, cmbavCtrgestiontareas_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, "HLP_Gx0020.htm");
            cmbavCtrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14cTrGestionTareas_Estado), 4, 0));
            AssignProp("", false, cmbavCtrgestiontareas_estado_Internalname, "Values", (String)(cmbavCtrgestiontareas_estado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18081_client"+"'", TempTags, "", 2, "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Gestion Tareas_ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Gestion Tareas_IDTablero") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tareas_Fecha Inicio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tareas_Fecha Fin") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A11TrGestionTareas_IDTablero.ToString());
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0020.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START082( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
            }
            Form.Meta.addItem("description", "Selection List Tr Gestion Tareas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP080( ) ;
      }

      protected void WS082( )
      {
         START082( ) ;
         EVT082( ) ;
      }

      protected void EVT082( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A12TrGestionTareas_ID = (long)(context.localUtil.CToN( cgiGet( edtTrGestionTareas_ID_Internalname), ".", ","));
                              A11TrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( edtTrGestionTareas_IDTablero_Internalname)));
                              A15TrGestionTareas_FechaInicio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTareas_FechaInicio_Internalname), 0));
                              n15TrGestionTareas_FechaInicio = false;
                              A16TrGestionTareas_FechaFin = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrGestionTareas_FechaFin_Internalname), 0));
                              n16TrGestionTareas_FechaFin = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ctrgestiontareas_id Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRGESTIONTAREAS_ID"), ".", ",") != Convert.ToDecimal( AV6cTrGestionTareas_ID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontareas_idtablero Changed */
                                       if ( StringUtil.StrToGuid( cgiGet( "GXH_vCTRGESTIONTAREAS_IDTABLERO")) != AV7cTrGestionTareas_IDTablero )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontareas_fechainicio Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRGESTIONTAREAS_FECHAINICIO"), 0) != AV8cTrGestionTareas_FechaInicio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontareas_fechafin Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRGESTIONTAREAS_FECHAFIN"), 0) != AV9cTrGestionTareas_FechaFin )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontareas_fechacreacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRGESTIONTAREAS_FECHACREACION"), 0) != AV10cTrGestionTareas_FechaCreacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontareas_fechamodificacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRGESTIONTAREAS_FECHAMODIFICACION"), 0) != AV11cTrGestionTareas_FechaModificacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrgestiontareas_estado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRGESTIONTAREAS_ESTADO"), ".", ",") != Convert.ToDecimal( AV14cTrGestionTareas_Estado )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21082 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE082( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA082( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cTrGestionTareas_ID ,
                                        Guid AV7cTrGestionTareas_IDTablero ,
                                        DateTime AV8cTrGestionTareas_FechaInicio ,
                                        DateTime AV9cTrGestionTareas_FechaFin ,
                                        DateTime AV10cTrGestionTareas_FechaCreacion ,
                                        DateTime AV11cTrGestionTareas_FechaModificacion ,
                                        short AV14cTrGestionTareas_Estado )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF082( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTAREAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A12TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRGESTIONTAREAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavCtrgestiontareas_estado.ItemCount > 0 )
         {
            AV14cTrGestionTareas_Estado = (short)(NumberUtil.Val( cmbavCtrgestiontareas_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14cTrGestionTareas_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV14cTrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV14cTrGestionTareas_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCtrgestiontareas_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14cTrGestionTareas_Estado), 4, 0));
            AssignProp("", false, cmbavCtrgestiontareas_estado_Internalname, "Values", cmbavCtrgestiontareas_estado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF082( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF082( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cTrGestionTareas_IDTablero ,
                                                 AV8cTrGestionTareas_FechaInicio ,
                                                 AV9cTrGestionTareas_FechaFin ,
                                                 AV10cTrGestionTareas_FechaCreacion ,
                                                 AV11cTrGestionTareas_FechaModificacion ,
                                                 AV14cTrGestionTareas_Estado ,
                                                 A11TrGestionTareas_IDTablero ,
                                                 A15TrGestionTareas_FechaInicio ,
                                                 A16TrGestionTareas_FechaFin ,
                                                 A17TrGestionTareas_FechaCreacion ,
                                                 A18TrGestionTareas_FechaModificacion ,
                                                 A24TrGestionTareas_Estado ,
                                                 AV6cTrGestionTareas_ID } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            } ) ;
            /* Using cursor H00082 */
            pr_default.execute(0, new Object[] {AV6cTrGestionTareas_ID, AV7cTrGestionTareas_IDTablero, AV8cTrGestionTareas_FechaInicio, AV9cTrGestionTareas_FechaFin, AV10cTrGestionTareas_FechaCreacion, AV11cTrGestionTareas_FechaModificacion, AV14cTrGestionTareas_Estado, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A24TrGestionTareas_Estado = H00082_A24TrGestionTareas_Estado[0];
               n24TrGestionTareas_Estado = H00082_n24TrGestionTareas_Estado[0];
               A18TrGestionTareas_FechaModificacion = H00082_A18TrGestionTareas_FechaModificacion[0];
               n18TrGestionTareas_FechaModificacion = H00082_n18TrGestionTareas_FechaModificacion[0];
               A17TrGestionTareas_FechaCreacion = H00082_A17TrGestionTareas_FechaCreacion[0];
               n17TrGestionTareas_FechaCreacion = H00082_n17TrGestionTareas_FechaCreacion[0];
               A16TrGestionTareas_FechaFin = H00082_A16TrGestionTareas_FechaFin[0];
               n16TrGestionTareas_FechaFin = H00082_n16TrGestionTareas_FechaFin[0];
               A15TrGestionTareas_FechaInicio = H00082_A15TrGestionTareas_FechaInicio[0];
               n15TrGestionTareas_FechaInicio = H00082_n15TrGestionTareas_FechaInicio[0];
               A11TrGestionTareas_IDTablero = (Guid)((Guid)(H00082_A11TrGestionTareas_IDTablero[0]));
               A12TrGestionTareas_ID = H00082_A12TrGestionTareas_ID[0];
               /* Execute user event: Load */
               E20082 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB080( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes082( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRGESTIONTAREAS_ID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A12TrGestionTareas_ID), "ZZZZZZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cTrGestionTareas_IDTablero ,
                                              AV8cTrGestionTareas_FechaInicio ,
                                              AV9cTrGestionTareas_FechaFin ,
                                              AV10cTrGestionTareas_FechaCreacion ,
                                              AV11cTrGestionTareas_FechaModificacion ,
                                              AV14cTrGestionTareas_Estado ,
                                              A11TrGestionTareas_IDTablero ,
                                              A15TrGestionTareas_FechaInicio ,
                                              A16TrGestionTareas_FechaFin ,
                                              A17TrGestionTareas_FechaCreacion ,
                                              A18TrGestionTareas_FechaModificacion ,
                                              A24TrGestionTareas_Estado ,
                                              AV6cTrGestionTareas_ID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         } ) ;
         /* Using cursor H00083 */
         pr_default.execute(1, new Object[] {AV6cTrGestionTareas_ID, AV7cTrGestionTareas_IDTablero, AV8cTrGestionTareas_FechaInicio, AV9cTrGestionTareas_FechaFin, AV10cTrGestionTareas_FechaCreacion, AV11cTrGestionTareas_FechaModificacion, AV14cTrGestionTareas_Estado});
         GRID1_nRecordCount = H00083_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTareas_ID, AV7cTrGestionTareas_IDTablero, AV8cTrGestionTareas_FechaInicio, AV9cTrGestionTareas_FechaFin, AV10cTrGestionTareas_FechaCreacion, AV11cTrGestionTareas_FechaModificacion, AV14cTrGestionTareas_Estado) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTareas_ID, AV7cTrGestionTareas_IDTablero, AV8cTrGestionTareas_FechaInicio, AV9cTrGestionTareas_FechaFin, AV10cTrGestionTareas_FechaCreacion, AV11cTrGestionTareas_FechaModificacion, AV14cTrGestionTareas_Estado) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTareas_ID, AV7cTrGestionTareas_IDTablero, AV8cTrGestionTareas_FechaInicio, AV9cTrGestionTareas_FechaFin, AV10cTrGestionTareas_FechaCreacion, AV11cTrGestionTareas_FechaModificacion, AV14cTrGestionTareas_Estado) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTareas_ID, AV7cTrGestionTareas_IDTablero, AV8cTrGestionTareas_FechaInicio, AV9cTrGestionTareas_FechaFin, AV10cTrGestionTareas_FechaCreacion, AV11cTrGestionTareas_FechaModificacion, AV14cTrGestionTareas_Estado) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrGestionTareas_ID, AV7cTrGestionTareas_IDTablero, AV8cTrGestionTareas_FechaInicio, AV9cTrGestionTareas_FechaFin, AV10cTrGestionTareas_FechaCreacion, AV11cTrGestionTareas_FechaModificacion, AV14cTrGestionTareas_Estado) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP080( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19082 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtrgestiontareas_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtrgestiontareas_id_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTRGESTIONTAREAS_ID");
               GX_FocusControl = edtavCtrgestiontareas_id_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cTrGestionTareas_ID = 0;
               AssignAttri("", false, "AV6cTrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV6cTrGestionTareas_ID), 13, 0));
            }
            else
            {
               AV6cTrGestionTareas_ID = (long)(context.localUtil.CToN( cgiGet( edtavCtrgestiontareas_id_Internalname), ".", ","));
               AssignAttri("", false, "AV6cTrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV6cTrGestionTareas_ID), 13, 0));
            }
            if ( StringUtil.StrCmp(cgiGet( edtavCtrgestiontareas_idtablero_Internalname), "") == 0 )
            {
               AV7cTrGestionTareas_IDTablero = (Guid)(Guid.Empty);
               AssignAttri("", false, "AV7cTrGestionTareas_IDTablero", AV7cTrGestionTareas_IDTablero.ToString());
            }
            else
            {
               try
               {
                  AV7cTrGestionTareas_IDTablero = (Guid)(StringUtil.StrToGuid( cgiGet( edtavCtrgestiontareas_idtablero_Internalname)));
                  AssignAttri("", false, "AV7cTrGestionTareas_IDTablero", AV7cTrGestionTareas_IDTablero.ToString());
               }
               catch ( Exception e )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vCTRGESTIONTAREAS_IDTABLERO");
                  GX_FocusControl = edtavCtrgestiontareas_idtablero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrgestiontareas_fechainicio_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Inicio"}), 1, "vCTRGESTIONTAREAS_FECHAINICIO");
               GX_FocusControl = edtavCtrgestiontareas_fechainicio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cTrGestionTareas_FechaInicio = DateTime.MinValue;
               AssignAttri("", false, "AV8cTrGestionTareas_FechaInicio", context.localUtil.Format(AV8cTrGestionTareas_FechaInicio, "99/99/9999"));
            }
            else
            {
               AV8cTrGestionTareas_FechaInicio = context.localUtil.CToD( cgiGet( edtavCtrgestiontareas_fechainicio_Internalname), 1);
               AssignAttri("", false, "AV8cTrGestionTareas_FechaInicio", context.localUtil.Format(AV8cTrGestionTareas_FechaInicio, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrgestiontareas_fechafin_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Fin"}), 1, "vCTRGESTIONTAREAS_FECHAFIN");
               GX_FocusControl = edtavCtrgestiontareas_fechafin_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cTrGestionTareas_FechaFin = DateTime.MinValue;
               AssignAttri("", false, "AV9cTrGestionTareas_FechaFin", context.localUtil.Format(AV9cTrGestionTareas_FechaFin, "99/99/9999"));
            }
            else
            {
               AV9cTrGestionTareas_FechaFin = context.localUtil.CToD( cgiGet( edtavCtrgestiontareas_fechafin_Internalname), 1);
               AssignAttri("", false, "AV9cTrGestionTareas_FechaFin", context.localUtil.Format(AV9cTrGestionTareas_FechaFin, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrgestiontareas_fechacreacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Creacion"}), 1, "vCTRGESTIONTAREAS_FECHACREACION");
               GX_FocusControl = edtavCtrgestiontareas_fechacreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cTrGestionTareas_FechaCreacion = DateTime.MinValue;
               AssignAttri("", false, "AV10cTrGestionTareas_FechaCreacion", context.localUtil.Format(AV10cTrGestionTareas_FechaCreacion, "99/99/9999"));
            }
            else
            {
               AV10cTrGestionTareas_FechaCreacion = context.localUtil.CToD( cgiGet( edtavCtrgestiontareas_fechacreacion_Internalname), 1);
               AssignAttri("", false, "AV10cTrGestionTareas_FechaCreacion", context.localUtil.Format(AV10cTrGestionTareas_FechaCreacion, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrgestiontareas_fechamodificacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Gestion Tareas_Fecha Modificacion"}), 1, "vCTRGESTIONTAREAS_FECHAMODIFICACION");
               GX_FocusControl = edtavCtrgestiontareas_fechamodificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cTrGestionTareas_FechaModificacion = DateTime.MinValue;
               AssignAttri("", false, "AV11cTrGestionTareas_FechaModificacion", context.localUtil.Format(AV11cTrGestionTareas_FechaModificacion, "99/99/9999"));
            }
            else
            {
               AV11cTrGestionTareas_FechaModificacion = context.localUtil.CToD( cgiGet( edtavCtrgestiontareas_fechamodificacion_Internalname), 1);
               AssignAttri("", false, "AV11cTrGestionTareas_FechaModificacion", context.localUtil.Format(AV11cTrGestionTareas_FechaModificacion, "99/99/9999"));
            }
            cmbavCtrgestiontareas_estado.Name = cmbavCtrgestiontareas_estado_Internalname;
            cmbavCtrgestiontareas_estado.CurrentValue = cgiGet( cmbavCtrgestiontareas_estado_Internalname);
            AV14cTrGestionTareas_Estado = (short)(NumberUtil.Val( cgiGet( cmbavCtrgestiontareas_estado_Internalname), "."));
            AssignAttri("", false, "AV14cTrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV14cTrGestionTareas_Estado), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRGESTIONTAREAS_ID"), ".", ",") != Convert.ToDecimal( AV6cTrGestionTareas_ID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToGuid( cgiGet( "GXH_vCTRGESTIONTAREAS_IDTABLERO")) != AV7cTrGestionTareas_IDTablero )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRGESTIONTAREAS_FECHAINICIO"), 1) != AV8cTrGestionTareas_FechaInicio )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRGESTIONTAREAS_FECHAFIN"), 1) != AV9cTrGestionTareas_FechaFin )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRGESTIONTAREAS_FECHACREACION"), 1) != AV10cTrGestionTareas_FechaCreacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRGESTIONTAREAS_FECHAMODIFICACION"), 1) != AV11cTrGestionTareas_FechaModificacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRGESTIONTAREAS_ESTADO"), ".", ",") != Convert.ToDecimal( AV14cTrGestionTareas_Estado )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E19082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19082( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Selection List %1", "Tr Gestion Tareas", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20082( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21082( )
      {
         /* Enter Routine */
         AV12pTrGestionTareas_ID = A12TrGestionTareas_ID;
         AssignAttri("", false, "AV12pTrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV12pTrGestionTareas_ID), 13, 0));
         context.setWebReturnParms(new Object[] {(long)AV12pTrGestionTareas_ID});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pTrGestionTareas_ID"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12pTrGestionTareas_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV12pTrGestionTareas_ID", StringUtil.LTrimStr( (decimal)(AV12pTrGestionTareas_ID), 13, 0));
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA082( ) ;
         WS082( ) ;
         WE082( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20221020219024", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx0020.js", "?20221020219024", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtTrGestionTareas_ID_Internalname = "TRGESTIONTAREAS_ID_"+sGXsfl_84_idx;
         edtTrGestionTareas_IDTablero_Internalname = "TRGESTIONTAREAS_IDTABLERO_"+sGXsfl_84_idx;
         edtTrGestionTareas_FechaInicio_Internalname = "TRGESTIONTAREAS_FECHAINICIO_"+sGXsfl_84_idx;
         edtTrGestionTareas_FechaFin_Internalname = "TRGESTIONTAREAS_FECHAFIN_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtTrGestionTareas_ID_Internalname = "TRGESTIONTAREAS_ID_"+sGXsfl_84_fel_idx;
         edtTrGestionTareas_IDTablero_Internalname = "TRGESTIONTAREAS_IDTABLERO_"+sGXsfl_84_fel_idx;
         edtTrGestionTareas_FechaInicio_Internalname = "TRGESTIONTAREAS_FECHAINICIO_"+sGXsfl_84_fel_idx;
         edtTrGestionTareas_FechaFin_Internalname = "TRGESTIONTAREAS_FECHAFIN_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB080( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)sImgUrl,(String)edtavLinkselection_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWActionColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12TrGestionTareas_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A12TrGestionTareas_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_ID_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_IDTablero_Internalname,A11TrGestionTareas_IDTablero.ToString(),A11TrGestionTareas_IDTablero.ToString(),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_IDTablero_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)36,(short)0,(short)0,(short)84,(short)1,(short)0,(short)0,(bool)true,(String)"",(String)"",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_FechaInicio_Internalname,context.localUtil.Format(A15TrGestionTareas_FechaInicio, "99/99/9999"),context.localUtil.Format( A15TrGestionTareas_FechaInicio, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_FechaInicio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrGestionTareas_FechaFin_Internalname,context.localUtil.Format(A16TrGestionTareas_FechaFin, "99/99/9999"),context.localUtil.Format( A16TrGestionTareas_FechaFin, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrGestionTareas_FechaFin_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes082( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         cmbavCtrgestiontareas_estado.Name = "vCTRGESTIONTAREAS_ESTADO";
         cmbavCtrgestiontareas_estado.WebTags = "";
         cmbavCtrgestiontareas_estado.addItem("1", "Nuevo", 0);
         cmbavCtrgestiontareas_estado.addItem("2", "En Progreso", 0);
         cmbavCtrgestiontareas_estado.addItem("3", "Completado", 0);
         cmbavCtrgestiontareas_estado.addItem("4", "Detenido", 0);
         cmbavCtrgestiontareas_estado.addItem("5", "Pendiente", 0);
         if ( cmbavCtrgestiontareas_estado.ItemCount > 0 )
         {
            AV14cTrGestionTareas_Estado = (short)(NumberUtil.Val( cmbavCtrgestiontareas_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14cTrGestionTareas_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV14cTrGestionTareas_Estado", StringUtil.LTrimStr( (decimal)(AV14cTrGestionTareas_Estado), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLbltrgestiontareas_idfilter_Internalname = "LBLTRGESTIONTAREAS_IDFILTER";
         edtavCtrgestiontareas_id_Internalname = "vCTRGESTIONTAREAS_ID";
         divTrgestiontareas_idfiltercontainer_Internalname = "TRGESTIONTAREAS_IDFILTERCONTAINER";
         lblLbltrgestiontareas_idtablerofilter_Internalname = "LBLTRGESTIONTAREAS_IDTABLEROFILTER";
         edtavCtrgestiontareas_idtablero_Internalname = "vCTRGESTIONTAREAS_IDTABLERO";
         divTrgestiontareas_idtablerofiltercontainer_Internalname = "TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER";
         lblLbltrgestiontareas_fechainiciofilter_Internalname = "LBLTRGESTIONTAREAS_FECHAINICIOFILTER";
         edtavCtrgestiontareas_fechainicio_Internalname = "vCTRGESTIONTAREAS_FECHAINICIO";
         divTrgestiontareas_fechainiciofiltercontainer_Internalname = "TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER";
         lblLbltrgestiontareas_fechafinfilter_Internalname = "LBLTRGESTIONTAREAS_FECHAFINFILTER";
         edtavCtrgestiontareas_fechafin_Internalname = "vCTRGESTIONTAREAS_FECHAFIN";
         divTrgestiontareas_fechafinfiltercontainer_Internalname = "TRGESTIONTAREAS_FECHAFINFILTERCONTAINER";
         lblLbltrgestiontareas_fechacreacionfilter_Internalname = "LBLTRGESTIONTAREAS_FECHACREACIONFILTER";
         edtavCtrgestiontareas_fechacreacion_Internalname = "vCTRGESTIONTAREAS_FECHACREACION";
         divTrgestiontareas_fechacreacionfiltercontainer_Internalname = "TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER";
         lblLbltrgestiontareas_fechamodificacionfilter_Internalname = "LBLTRGESTIONTAREAS_FECHAMODIFICACIONFILTER";
         edtavCtrgestiontareas_fechamodificacion_Internalname = "vCTRGESTIONTAREAS_FECHAMODIFICACION";
         divTrgestiontareas_fechamodificacionfiltercontainer_Internalname = "TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER";
         lblLbltrgestiontareas_estadofilter_Internalname = "LBLTRGESTIONTAREAS_ESTADOFILTER";
         cmbavCtrgestiontareas_estado_Internalname = "vCTRGESTIONTAREAS_ESTADO";
         divTrgestiontareas_estadofiltercontainer_Internalname = "TRGESTIONTAREAS_ESTADOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTrGestionTareas_ID_Internalname = "TRGESTIONTAREAS_ID";
         edtTrGestionTareas_IDTablero_Internalname = "TRGESTIONTAREAS_IDTABLERO";
         edtTrGestionTareas_FechaInicio_Internalname = "TRGESTIONTAREAS_FECHAINICIO";
         edtTrGestionTareas_FechaFin_Internalname = "TRGESTIONTAREAS_FECHAFIN";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtTrGestionTareas_FechaFin_Jsonclick = "";
         edtTrGestionTareas_FechaInicio_Jsonclick = "";
         edtTrGestionTareas_IDTablero_Jsonclick = "";
         edtTrGestionTareas_ID_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         cmbavCtrgestiontareas_estado_Jsonclick = "";
         cmbavCtrgestiontareas_estado.Enabled = 1;
         cmbavCtrgestiontareas_estado.Visible = 1;
         edtavCtrgestiontareas_fechamodificacion_Jsonclick = "";
         edtavCtrgestiontareas_fechamodificacion_Enabled = 1;
         edtavCtrgestiontareas_fechacreacion_Jsonclick = "";
         edtavCtrgestiontareas_fechacreacion_Enabled = 1;
         edtavCtrgestiontareas_fechafin_Jsonclick = "";
         edtavCtrgestiontareas_fechafin_Enabled = 1;
         edtavCtrgestiontareas_fechainicio_Jsonclick = "";
         edtavCtrgestiontareas_fechainicio_Enabled = 1;
         edtavCtrgestiontareas_idtablero_Jsonclick = "";
         edtavCtrgestiontareas_idtablero_Enabled = 1;
         edtavCtrgestiontareas_idtablero_Visible = 1;
         edtavCtrgestiontareas_id_Jsonclick = "";
         edtavCtrgestiontareas_id_Enabled = 1;
         edtavCtrgestiontareas_id_Visible = 1;
         divTrgestiontareas_estadofiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontareas_fechamodificacionfiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontareas_fechacreacionfiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontareas_fechafinfiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontareas_fechainiciofiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontareas_idtablerofiltercontainer_Class = "AdvancedContainerItem";
         divTrgestiontareas_idfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Tr Gestion Tareas";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTareas_ID',fld:'vCTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrGestionTareas_IDTablero',fld:'vCTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV8cTrGestionTareas_FechaInicio',fld:'vCTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV9cTrGestionTareas_FechaFin',fld:'vCTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'AV10cTrGestionTareas_FechaCreacion',fld:'vCTRGESTIONTAREAS_FECHACREACION',pic:''},{av:'AV11cTrGestionTareas_FechaModificacion',fld:'vCTRGESTIONTAREAS_FECHAMODIFICACION',pic:''},{av:'cmbavCtrgestiontareas_estado'},{av:'AV14cTrGestionTareas_Estado',fld:'vCTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18081',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTAREAS_IDFILTER.CLICK","{handler:'E11081',iparms:[{av:'divTrgestiontareas_idfiltercontainer_Class',ctrl:'TRGESTIONTAREAS_IDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTAREAS_IDFILTER.CLICK",",oparms:[{av:'divTrgestiontareas_idfiltercontainer_Class',ctrl:'TRGESTIONTAREAS_IDFILTERCONTAINER',prop:'Class'},{av:'edtavCtrgestiontareas_id_Visible',ctrl:'vCTRGESTIONTAREAS_ID',prop:'Visible'}]}");
         setEventMetadata("LBLTRGESTIONTAREAS_IDTABLEROFILTER.CLICK","{handler:'E12081',iparms:[{av:'divTrgestiontareas_idtablerofiltercontainer_Class',ctrl:'TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTAREAS_IDTABLEROFILTER.CLICK",",oparms:[{av:'divTrgestiontareas_idtablerofiltercontainer_Class',ctrl:'TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER',prop:'Class'},{av:'edtavCtrgestiontareas_idtablero_Visible',ctrl:'vCTRGESTIONTAREAS_IDTABLERO',prop:'Visible'}]}");
         setEventMetadata("LBLTRGESTIONTAREAS_FECHAINICIOFILTER.CLICK","{handler:'E13081',iparms:[{av:'divTrgestiontareas_fechainiciofiltercontainer_Class',ctrl:'TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTAREAS_FECHAINICIOFILTER.CLICK",",oparms:[{av:'divTrgestiontareas_fechainiciofiltercontainer_Class',ctrl:'TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTAREAS_FECHAFINFILTER.CLICK","{handler:'E14081',iparms:[{av:'divTrgestiontareas_fechafinfiltercontainer_Class',ctrl:'TRGESTIONTAREAS_FECHAFINFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTAREAS_FECHAFINFILTER.CLICK",",oparms:[{av:'divTrgestiontareas_fechafinfiltercontainer_Class',ctrl:'TRGESTIONTAREAS_FECHAFINFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTAREAS_FECHACREACIONFILTER.CLICK","{handler:'E15081',iparms:[{av:'divTrgestiontareas_fechacreacionfiltercontainer_Class',ctrl:'TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTAREAS_FECHACREACIONFILTER.CLICK",",oparms:[{av:'divTrgestiontareas_fechacreacionfiltercontainer_Class',ctrl:'TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTAREAS_FECHAMODIFICACIONFILTER.CLICK","{handler:'E16081',iparms:[{av:'divTrgestiontareas_fechamodificacionfiltercontainer_Class',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTAREAS_FECHAMODIFICACIONFILTER.CLICK",",oparms:[{av:'divTrgestiontareas_fechamodificacionfiltercontainer_Class',ctrl:'TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRGESTIONTAREAS_ESTADOFILTER.CLICK","{handler:'E17081',iparms:[{av:'divTrgestiontareas_estadofiltercontainer_Class',ctrl:'TRGESTIONTAREAS_ESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRGESTIONTAREAS_ESTADOFILTER.CLICK",",oparms:[{av:'divTrgestiontareas_estadofiltercontainer_Class',ctrl:'TRGESTIONTAREAS_ESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCtrgestiontareas_estado'}]}");
         setEventMetadata("ENTER","{handler:'E21082',iparms:[{av:'A12TrGestionTareas_ID',fld:'TRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pTrGestionTareas_ID',fld:'vPTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTareas_ID',fld:'vCTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrGestionTareas_IDTablero',fld:'vCTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV8cTrGestionTareas_FechaInicio',fld:'vCTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV9cTrGestionTareas_FechaFin',fld:'vCTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'AV10cTrGestionTareas_FechaCreacion',fld:'vCTRGESTIONTAREAS_FECHACREACION',pic:''},{av:'AV11cTrGestionTareas_FechaModificacion',fld:'vCTRGESTIONTAREAS_FECHAMODIFICACION',pic:''},{av:'cmbavCtrgestiontareas_estado'},{av:'AV14cTrGestionTareas_Estado',fld:'vCTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTareas_ID',fld:'vCTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrGestionTareas_IDTablero',fld:'vCTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV8cTrGestionTareas_FechaInicio',fld:'vCTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV9cTrGestionTareas_FechaFin',fld:'vCTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'AV10cTrGestionTareas_FechaCreacion',fld:'vCTRGESTIONTAREAS_FECHACREACION',pic:''},{av:'AV11cTrGestionTareas_FechaModificacion',fld:'vCTRGESTIONTAREAS_FECHAMODIFICACION',pic:''},{av:'cmbavCtrgestiontareas_estado'},{av:'AV14cTrGestionTareas_Estado',fld:'vCTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTareas_ID',fld:'vCTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrGestionTareas_IDTablero',fld:'vCTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV8cTrGestionTareas_FechaInicio',fld:'vCTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV9cTrGestionTareas_FechaFin',fld:'vCTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'AV10cTrGestionTareas_FechaCreacion',fld:'vCTRGESTIONTAREAS_FECHACREACION',pic:''},{av:'AV11cTrGestionTareas_FechaModificacion',fld:'vCTRGESTIONTAREAS_FECHAMODIFICACION',pic:''},{av:'cmbavCtrgestiontareas_estado'},{av:'AV14cTrGestionTareas_Estado',fld:'vCTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrGestionTareas_ID',fld:'vCTRGESTIONTAREAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrGestionTareas_IDTablero',fld:'vCTRGESTIONTAREAS_IDTABLERO',pic:''},{av:'AV8cTrGestionTareas_FechaInicio',fld:'vCTRGESTIONTAREAS_FECHAINICIO',pic:''},{av:'AV9cTrGestionTareas_FechaFin',fld:'vCTRGESTIONTAREAS_FECHAFIN',pic:''},{av:'AV10cTrGestionTareas_FechaCreacion',fld:'vCTRGESTIONTAREAS_FECHACREACION',pic:''},{av:'AV11cTrGestionTareas_FechaModificacion',fld:'vCTRGESTIONTAREAS_FECHAMODIFICACION',pic:''},{av:'cmbavCtrgestiontareas_estado'},{av:'AV14cTrGestionTareas_Estado',fld:'vCTRGESTIONTAREAS_ESTADO',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_IDTABLERO","{handler:'Validv_Ctrgestiontareas_idtablero',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_IDTABLERO",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_FECHAINICIO","{handler:'Validv_Ctrgestiontareas_fechainicio',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_FECHAINICIO",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_FECHAFIN","{handler:'Validv_Ctrgestiontareas_fechafin',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_FECHAFIN",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_FECHACREACION","{handler:'Validv_Ctrgestiontareas_fechacreacion',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_FECHAMODIFICACION","{handler:'Validv_Ctrgestiontareas_fechamodificacion',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_ESTADO","{handler:'Validv_Ctrgestiontareas_estado',iparms:[]");
         setEventMetadata("VALIDV_CTRGESTIONTAREAS_ESTADO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Trgestiontareas_fechafin',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7cTrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         AV8cTrGestionTareas_FechaInicio = DateTime.MinValue;
         AV9cTrGestionTareas_FechaFin = DateTime.MinValue;
         AV10cTrGestionTareas_FechaCreacion = DateTime.MinValue;
         AV11cTrGestionTareas_FechaModificacion = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbltrgestiontareas_idfilter_Jsonclick = "";
         TempTags = "";
         lblLbltrgestiontareas_idtablerofilter_Jsonclick = "";
         lblLbltrgestiontareas_fechainiciofilter_Jsonclick = "";
         lblLbltrgestiontareas_fechafinfilter_Jsonclick = "";
         lblLbltrgestiontareas_fechacreacionfilter_Jsonclick = "";
         lblLbltrgestiontareas_fechamodificacionfilter_Jsonclick = "";
         lblLbltrgestiontareas_estadofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A11TrGestionTareas_IDTablero = (Guid)(Guid.Empty);
         A15TrGestionTareas_FechaInicio = DateTime.MinValue;
         A16TrGestionTareas_FechaFin = DateTime.MinValue;
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         A17TrGestionTareas_FechaCreacion = DateTime.MinValue;
         A18TrGestionTareas_FechaModificacion = DateTime.MinValue;
         H00082_A24TrGestionTareas_Estado = new short[1] ;
         H00082_n24TrGestionTareas_Estado = new bool[] {false} ;
         H00082_A18TrGestionTareas_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         H00082_n18TrGestionTareas_FechaModificacion = new bool[] {false} ;
         H00082_A17TrGestionTareas_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H00082_n17TrGestionTareas_FechaCreacion = new bool[] {false} ;
         H00082_A16TrGestionTareas_FechaFin = new DateTime[] {DateTime.MinValue} ;
         H00082_n16TrGestionTareas_FechaFin = new bool[] {false} ;
         H00082_A15TrGestionTareas_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         H00082_n15TrGestionTareas_FechaInicio = new bool[] {false} ;
         H00082_A11TrGestionTareas_IDTablero = new Guid[] {Guid.Empty} ;
         H00082_A12TrGestionTareas_ID = new long[1] ;
         H00083_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0020__default(),
            new Object[][] {
                new Object[] {
               H00082_A24TrGestionTareas_Estado, H00082_n24TrGestionTareas_Estado, H00082_A18TrGestionTareas_FechaModificacion, H00082_n18TrGestionTareas_FechaModificacion, H00082_A17TrGestionTareas_FechaCreacion, H00082_n17TrGestionTareas_FechaCreacion, H00082_A16TrGestionTareas_FechaFin, H00082_n16TrGestionTareas_FechaFin, H00082_A15TrGestionTareas_FechaInicio, H00082_n15TrGestionTareas_FechaInicio,
               H00082_A11TrGestionTareas_IDTablero, H00082_A12TrGestionTareas_ID
               }
               , new Object[] {
               H00083_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV14cTrGestionTareas_Estado ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A24TrGestionTareas_Estado ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCtrgestiontareas_id_Enabled ;
      private int edtavCtrgestiontareas_id_Visible ;
      private int edtavCtrgestiontareas_idtablero_Visible ;
      private int edtavCtrgestiontareas_idtablero_Enabled ;
      private int edtavCtrgestiontareas_fechainicio_Enabled ;
      private int edtavCtrgestiontareas_fechafin_Enabled ;
      private int edtavCtrgestiontareas_fechacreacion_Enabled ;
      private int edtavCtrgestiontareas_fechamodificacion_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cTrGestionTareas_ID ;
      private long AV12pTrGestionTareas_ID ;
      private long A12TrGestionTareas_ID ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private String divAdvancedcontainer_Class ;
      private String bttBtntoggle_Class ;
      private String divTrgestiontareas_idfiltercontainer_Class ;
      private String divTrgestiontareas_idtablerofiltercontainer_Class ;
      private String divTrgestiontareas_fechainiciofiltercontainer_Class ;
      private String divTrgestiontareas_fechafinfiltercontainer_Class ;
      private String divTrgestiontareas_fechacreacionfiltercontainer_Class ;
      private String divTrgestiontareas_fechamodificacionfiltercontainer_Class ;
      private String divTrgestiontareas_estadofiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_84_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMain_Internalname ;
      private String divAdvancedcontainer_Internalname ;
      private String divTrgestiontareas_idfiltercontainer_Internalname ;
      private String lblLbltrgestiontareas_idfilter_Internalname ;
      private String lblLbltrgestiontareas_idfilter_Jsonclick ;
      private String edtavCtrgestiontareas_id_Internalname ;
      private String TempTags ;
      private String edtavCtrgestiontareas_id_Jsonclick ;
      private String divTrgestiontareas_idtablerofiltercontainer_Internalname ;
      private String lblLbltrgestiontareas_idtablerofilter_Internalname ;
      private String lblLbltrgestiontareas_idtablerofilter_Jsonclick ;
      private String edtavCtrgestiontareas_idtablero_Internalname ;
      private String edtavCtrgestiontareas_idtablero_Jsonclick ;
      private String divTrgestiontareas_fechainiciofiltercontainer_Internalname ;
      private String lblLbltrgestiontareas_fechainiciofilter_Internalname ;
      private String lblLbltrgestiontareas_fechainiciofilter_Jsonclick ;
      private String edtavCtrgestiontareas_fechainicio_Internalname ;
      private String edtavCtrgestiontareas_fechainicio_Jsonclick ;
      private String divTrgestiontareas_fechafinfiltercontainer_Internalname ;
      private String lblLbltrgestiontareas_fechafinfilter_Internalname ;
      private String lblLbltrgestiontareas_fechafinfilter_Jsonclick ;
      private String edtavCtrgestiontareas_fechafin_Internalname ;
      private String edtavCtrgestiontareas_fechafin_Jsonclick ;
      private String divTrgestiontareas_fechacreacionfiltercontainer_Internalname ;
      private String lblLbltrgestiontareas_fechacreacionfilter_Internalname ;
      private String lblLbltrgestiontareas_fechacreacionfilter_Jsonclick ;
      private String edtavCtrgestiontareas_fechacreacion_Internalname ;
      private String edtavCtrgestiontareas_fechacreacion_Jsonclick ;
      private String divTrgestiontareas_fechamodificacionfiltercontainer_Internalname ;
      private String lblLbltrgestiontareas_fechamodificacionfilter_Internalname ;
      private String lblLbltrgestiontareas_fechamodificacionfilter_Jsonclick ;
      private String edtavCtrgestiontareas_fechamodificacion_Internalname ;
      private String edtavCtrgestiontareas_fechamodificacion_Jsonclick ;
      private String divTrgestiontareas_estadofiltercontainer_Internalname ;
      private String lblLbltrgestiontareas_estadofilter_Internalname ;
      private String lblLbltrgestiontareas_estadofilter_Jsonclick ;
      private String cmbavCtrgestiontareas_estado_Internalname ;
      private String cmbavCtrgestiontareas_estado_Jsonclick ;
      private String divGridtable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtntoggle_Internalname ;
      private String bttBtntoggle_Jsonclick ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String edtavLinkselection_Link ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavLinkselection_Internalname ;
      private String edtTrGestionTareas_ID_Internalname ;
      private String edtTrGestionTareas_IDTablero_Internalname ;
      private String edtTrGestionTareas_FechaInicio_Internalname ;
      private String edtTrGestionTareas_FechaFin_Internalname ;
      private String scmdbuf ;
      private String AV13ADVANCED_LABEL_TEMPLATE ;
      private String sGXsfl_84_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtTrGestionTareas_ID_Jsonclick ;
      private String edtTrGestionTareas_IDTablero_Jsonclick ;
      private String edtTrGestionTareas_FechaInicio_Jsonclick ;
      private String edtTrGestionTareas_FechaFin_Jsonclick ;
      private DateTime AV8cTrGestionTareas_FechaInicio ;
      private DateTime AV9cTrGestionTareas_FechaFin ;
      private DateTime AV10cTrGestionTareas_FechaCreacion ;
      private DateTime AV11cTrGestionTareas_FechaModificacion ;
      private DateTime A15TrGestionTareas_FechaInicio ;
      private DateTime A16TrGestionTareas_FechaFin ;
      private DateTime A17TrGestionTareas_FechaCreacion ;
      private DateTime A18TrGestionTareas_FechaModificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n15TrGestionTareas_FechaInicio ;
      private bool n16TrGestionTareas_FechaFin ;
      private bool gxdyncontrolsrefreshing ;
      private bool n24TrGestionTareas_Estado ;
      private bool n18TrGestionTareas_FechaModificacion ;
      private bool n17TrGestionTareas_FechaCreacion ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private String AV17Linkselection_GXI ;
      private String AV5LinkSelection ;
      private Guid AV7cTrGestionTareas_IDTablero ;
      private Guid A11TrGestionTareas_IDTablero ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCtrgestiontareas_estado ;
      private IDataStoreProvider pr_default ;
      private short[] H00082_A24TrGestionTareas_Estado ;
      private bool[] H00082_n24TrGestionTareas_Estado ;
      private DateTime[] H00082_A18TrGestionTareas_FechaModificacion ;
      private bool[] H00082_n18TrGestionTareas_FechaModificacion ;
      private DateTime[] H00082_A17TrGestionTareas_FechaCreacion ;
      private bool[] H00082_n17TrGestionTareas_FechaCreacion ;
      private DateTime[] H00082_A16TrGestionTareas_FechaFin ;
      private bool[] H00082_n16TrGestionTareas_FechaFin ;
      private DateTime[] H00082_A15TrGestionTareas_FechaInicio ;
      private bool[] H00082_n15TrGestionTareas_FechaInicio ;
      private Guid[] H00082_A11TrGestionTareas_IDTablero ;
      private long[] H00082_A12TrGestionTareas_ID ;
      private long[] H00083_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pTrGestionTareas_ID ;
      private GXWebForm Form ;
   }

   public class gx0020__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00082( IGxContext context ,
                                             Guid AV7cTrGestionTareas_IDTablero ,
                                             DateTime AV8cTrGestionTareas_FechaInicio ,
                                             DateTime AV9cTrGestionTareas_FechaFin ,
                                             DateTime AV10cTrGestionTareas_FechaCreacion ,
                                             DateTime AV11cTrGestionTareas_FechaModificacion ,
                                             short AV14cTrGestionTareas_Estado ,
                                             Guid A11TrGestionTareas_IDTablero ,
                                             DateTime A15TrGestionTareas_FechaInicio ,
                                             DateTime A16TrGestionTareas_FechaFin ,
                                             DateTime A17TrGestionTareas_FechaCreacion ,
                                             DateTime A18TrGestionTareas_FechaModificacion ,
                                             short A24TrGestionTareas_Estado ,
                                             long AV6cTrGestionTareas_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [10] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [TrGestionTareas_Estado], [TrGestionTareas_FechaModificacion], [TrGestionTareas_FechaCreacion], [TrGestionTareas_FechaFin], [TrGestionTareas_FechaInicio], [TrGestionTareas_IDTablero], [TrGestionTareas_ID]";
         sFromString = " FROM TABLERO.[TrGestionTareas]";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE ([TrGestionTareas_ID] >= @AV6cTrGestionTareas_ID)";
         if ( ! (Guid.Empty==AV7cTrGestionTareas_IDTablero) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_IDTablero] >= @AV7cTrGestionTareas_IDTablero)";
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTrGestionTareas_FechaInicio) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_FechaInicio] >= @AV8cTrGestionTareas_FechaInicio)";
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTrGestionTareas_FechaFin) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_FechaFin] >= @AV9cTrGestionTareas_FechaFin)";
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cTrGestionTareas_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_FechaCreacion] >= @AV10cTrGestionTareas_FechaCreacion)";
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cTrGestionTareas_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_FechaModificacion] >= @AV11cTrGestionTareas_FechaModificacion)";
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV14cTrGestionTareas_Estado) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_Estado] >= @AV14cTrGestionTareas_Estado)";
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString = sOrderString + " ORDER BY [TrGestionTareas_ID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00083( IGxContext context ,
                                             Guid AV7cTrGestionTareas_IDTablero ,
                                             DateTime AV8cTrGestionTareas_FechaInicio ,
                                             DateTime AV9cTrGestionTareas_FechaFin ,
                                             DateTime AV10cTrGestionTareas_FechaCreacion ,
                                             DateTime AV11cTrGestionTareas_FechaModificacion ,
                                             short AV14cTrGestionTareas_Estado ,
                                             Guid A11TrGestionTareas_IDTablero ,
                                             DateTime A15TrGestionTareas_FechaInicio ,
                                             DateTime A16TrGestionTareas_FechaFin ,
                                             DateTime A17TrGestionTareas_FechaCreacion ,
                                             DateTime A18TrGestionTareas_FechaModificacion ,
                                             short A24TrGestionTareas_Estado ,
                                             long AV6cTrGestionTareas_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [7] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM TABLERO.[TrGestionTareas]";
         scmdbuf = scmdbuf + " WHERE ([TrGestionTareas_ID] >= @AV6cTrGestionTareas_ID)";
         if ( ! (Guid.Empty==AV7cTrGestionTareas_IDTablero) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_IDTablero] >= @AV7cTrGestionTareas_IDTablero)";
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTrGestionTareas_FechaInicio) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_FechaInicio] >= @AV8cTrGestionTareas_FechaInicio)";
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTrGestionTareas_FechaFin) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_FechaFin] >= @AV9cTrGestionTareas_FechaFin)";
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cTrGestionTareas_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_FechaCreacion] >= @AV10cTrGestionTareas_FechaCreacion)";
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cTrGestionTareas_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_FechaModificacion] >= @AV11cTrGestionTareas_FechaModificacion)";
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV14cTrGestionTareas_Estado) )
         {
            sWhereString = sWhereString + " and ([TrGestionTareas_Estado] >= @AV14cTrGestionTareas_Estado)";
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + "";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00082(context, (Guid)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (Guid)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H00083(context, (Guid)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (Guid)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00082 ;
          prmH00082 = new Object[] {
          new Object[] {"@AV6cTrGestionTareas_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV7cTrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@AV8cTrGestionTareas_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV9cTrGestionTareas_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV10cTrGestionTareas_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV11cTrGestionTareas_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV14cTrGestionTareas_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00083 ;
          prmH00083 = new Object[] {
          new Object[] {"@AV6cTrGestionTareas_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV7cTrGestionTareas_IDTablero",SqlDbType.UniqueIdentifier,4,0} ,
          new Object[] {"@AV8cTrGestionTareas_FechaInicio",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV9cTrGestionTareas_FechaFin",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV10cTrGestionTareas_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV11cTrGestionTareas_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV14cTrGestionTareas_Estado",SqlDbType.SmallInt,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00082", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00082,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00083", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00083,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((Guid[]) buf[10])[0] = rslt.getGuid(6) ;
                ((long[]) buf[11])[0] = rslt.getLong(7) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[10]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (Guid)parms[11]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[12]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[13]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[14]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[15]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[16]);
                }
                if ( (short)parms[7] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[17]);
                }
                if ( (short)parms[8] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[18]);
                }
                if ( (short)parms[9] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[19]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[7]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (Guid)parms[8]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[9]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[10]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[11]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[12]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[13]);
                }
                return;
       }
    }

 }

}
