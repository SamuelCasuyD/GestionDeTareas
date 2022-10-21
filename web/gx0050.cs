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
   public class gx0050 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0050( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public gx0050( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out long aP0_pTrTareaComentarios_ID )
      {
         this.AV11pTrTareaComentarios_ID = 0 ;
         executePrivate();
         aP0_pTrTareaComentarios_ID=this.AV11pTrTareaComentarios_ID;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCtrtareacomentarios_estado = new GXCombobox();
         cmbTrTareaComentarios_Estado = new GXCombobox();
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
               nRC_GXsfl_64 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_64_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_64_idx = GetNextPar( );
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
               AV6cTrTareaComentarios_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV7cTrTareaComentarios_IDTarea = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV8cTrTareaComentarios_Estado = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV9cTrTareaComentarios_FechaCreacion = context.localUtil.ParseDateParm( GetNextPar( ));
               AV10cTrTareaComentarios_FechaModificacion = context.localUtil.ParseDateParm( GetNextPar( ));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareaComentarios_ID, AV7cTrTareaComentarios_IDTarea, AV8cTrTareaComentarios_Estado, AV9cTrTareaComentarios_FechaCreacion, AV10cTrTareaComentarios_FechaModificacion) ;
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
               AV11pTrTareaComentarios_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV11pTrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(AV11pTrTareaComentarios_ID), 13, 0));
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
         PA232( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START232( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202210202136482", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0050.aspx") + "?" + UrlEncode("" +AV11pTrTareaComentarios_ID)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCTRTAREACOMENTARIOS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTrTareaComentarios_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRTAREACOMENTARIOS_IDTAREA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cTrTareaComentarios_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRTAREACOMENTARIOS_ESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cTrTareaComentarios_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRTAREACOMENTARIOS_FECHACREACION", context.localUtil.Format(AV9cTrTareaComentarios_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRTAREACOMENTARIOS_FECHAMODIFICACION", context.localUtil.Format(AV10cTrTareaComentarios_FechaModificacion, "99/99/9999"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPTRTAREACOMENTARIOS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pTrTareaComentarios_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TRTAREACOMENTARIOS_IDFILTERCONTAINER_Class", StringUtil.RTrim( divTrtareacomentarios_idfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRTAREACOMENTARIOS_IDTAREAFILTERCONTAINER_Class", StringUtil.RTrim( divTrtareacomentarios_idtareafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRTAREACOMENTARIOS_ESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divTrtareacomentarios_estadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRTAREACOMENTARIOS_FECHACREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTrtareacomentarios_fechacreacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRTAREACOMENTARIOS_FECHAMODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTrtareacomentarios_fechamodificacionfiltercontainer_Class));
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
            WE232( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT232( ) ;
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
         return formatLink("gx0050.aspx") + "?" + UrlEncode("" +AV11pTrTareaComentarios_ID) ;
      }

      public override String GetPgmname( )
      {
         return "Gx0050" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Tr Tarea Comentarios" ;
      }

      protected void WB230( )
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
            GxWebStd.gx_div_start( context, divTrtareacomentarios_idfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrtareacomentarios_idfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrtareacomentarios_idfilter_Internalname, "Tr Tarea Comentarios_ID", "", "", lblLbltrtareacomentarios_idfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11231_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrtareacomentarios_id_Internalname, "Tr Tarea Comentarios_ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrtareacomentarios_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTrTareaComentarios_ID), 13, 0, ".", "")), ((edtavCtrtareacomentarios_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cTrTareaComentarios_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cTrTareaComentarios_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrtareacomentarios_id_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrtareacomentarios_id_Visible, edtavCtrtareacomentarios_id_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divTrtareacomentarios_idtareafiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrtareacomentarios_idtareafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrtareacomentarios_idtareafilter_Internalname, "Tr Tarea Comentarios_IDTarea", "", "", lblLbltrtareacomentarios_idtareafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12231_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrtareacomentarios_idtarea_Internalname, "Tr Tarea Comentarios_IDTarea", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrtareacomentarios_idtarea_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cTrTareaComentarios_IDTarea), 13, 0, ".", "")), ((edtavCtrtareacomentarios_idtarea_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7cTrTareaComentarios_IDTarea), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV7cTrTareaComentarios_IDTarea), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrtareacomentarios_idtarea_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrtareacomentarios_idtarea_Visible, edtavCtrtareacomentarios_idtarea_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divTrtareacomentarios_estadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrtareacomentarios_estadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrtareacomentarios_estadofilter_Internalname, "Tr Tarea Comentarios_Estado", "", "", lblLbltrtareacomentarios_estadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13231_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCtrtareacomentarios_estado_Internalname, "Tr Tarea Comentarios_Estado", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCtrtareacomentarios_estado, cmbavCtrtareacomentarios_estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8cTrTareaComentarios_Estado), 4, 0)), 1, cmbavCtrtareacomentarios_estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavCtrtareacomentarios_estado.Visible, cmbavCtrtareacomentarios_estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, "HLP_Gx0050.htm");
            cmbavCtrtareacomentarios_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8cTrTareaComentarios_Estado), 4, 0));
            AssignProp("", false, cmbavCtrtareacomentarios_estado_Internalname, "Values", (String)(cmbavCtrtareacomentarios_estado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTrtareacomentarios_fechacreacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrtareacomentarios_fechacreacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrtareacomentarios_fechacreacionfilter_Internalname, "Tr Tarea Comentarios_Fecha Creacion", "", "", lblLbltrtareacomentarios_fechacreacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14231_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrtareacomentarios_fechacreacion_Internalname, "Tr Tarea Comentarios_Fecha Creacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrtareacomentarios_fechacreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrtareacomentarios_fechacreacion_Internalname, context.localUtil.Format(AV9cTrTareaComentarios_FechaCreacion, "99/99/9999"), context.localUtil.Format( AV9cTrTareaComentarios_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrtareacomentarios_fechacreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrtareacomentarios_fechacreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divTrtareacomentarios_fechamodificacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrtareacomentarios_fechamodificacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrtareacomentarios_fechamodificacionfilter_Internalname, "Tr Tarea Comentarios_Fecha Modificacion", "", "", lblLbltrtareacomentarios_fechamodificacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15231_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrtareacomentarios_fechamodificacion_Internalname, "Tr Tarea Comentarios_Fecha Modificacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtrtareacomentarios_fechamodificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtrtareacomentarios_fechamodificacion_Internalname, context.localUtil.Format(AV10cTrTareaComentarios_FechaModificacion, "99/99/9999"), context.localUtil.Format( AV10cTrTareaComentarios_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrtareacomentarios_fechamodificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtrtareacomentarios_fechamodificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0050.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16231_client"+"'", TempTags, "", 2, "HLP_Gx0050.htm");
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
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
               context.SendWebValue( "Tarea Comentarios_ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tarea Comentarios_IDTarea") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tarea Comentarios_Estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Comentarios_Fecha Creacion") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A35TrTareaComentarios_ID), 13, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37TrTareaComentarios_Estado), 4, 0, ".", "")));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( cmbTrTareaComentarios_Estado.Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"));
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
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 64 )
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

      protected void START232( )
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
            Form.Meta.addItem("description", "Selection List Tr Tarea Comentarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP230( ) ;
      }

      protected void WS232( )
      {
         START232( ) ;
         EVT232( ) ;
      }

      protected void EVT232( )
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
                              nGXsfl_64_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A35TrTareaComentarios_ID = (long)(context.localUtil.CToN( cgiGet( edtTrTareaComentarios_ID_Internalname), ".", ","));
                              A34TrTareaComentarios_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtTrTareaComentarios_IDTarea_Internalname), ".", ","));
                              n34TrTareaComentarios_IDTarea = false;
                              cmbTrTareaComentarios_Estado.Name = cmbTrTareaComentarios_Estado_Internalname;
                              cmbTrTareaComentarios_Estado.CurrentValue = cgiGet( cmbTrTareaComentarios_Estado_Internalname);
                              A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrTareaComentarios_Estado_Internalname), "."));
                              n37TrTareaComentarios_Estado = false;
                              A38TrTareaComentarios_FechaCreacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTrTareaComentarios_FechaCreacion_Internalname), 0));
                              n38TrTareaComentarios_FechaCreacion = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ctrtareacomentarios_id Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREACOMENTARIOS_ID"), ".", ",") != Convert.ToDecimal( AV6cTrTareaComentarios_ID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrtareacomentarios_idtarea Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREACOMENTARIOS_IDTAREA"), ".", ",") != Convert.ToDecimal( AV7cTrTareaComentarios_IDTarea )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrtareacomentarios_estado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREACOMENTARIOS_ESTADO"), ".", ",") != Convert.ToDecimal( AV8cTrTareaComentarios_Estado )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrtareacomentarios_fechacreacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRTAREACOMENTARIOS_FECHACREACION"), 0) != AV9cTrTareaComentarios_FechaCreacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrtareacomentarios_fechamodificacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTRTAREACOMENTARIOS_FECHAMODIFICACION"), 0) != AV10cTrTareaComentarios_FechaModificacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19232 ();
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

      protected void WE232( )
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

      protected void PA232( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cTrTareaComentarios_ID ,
                                        long AV7cTrTareaComentarios_IDTarea ,
                                        short AV8cTrTareaComentarios_Estado ,
                                        DateTime AV9cTrTareaComentarios_FechaCreacion ,
                                        DateTime AV10cTrTareaComentarios_FechaModificacion )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF232( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRTAREACOMENTARIOS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A35TrTareaComentarios_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRTAREACOMENTARIOS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A35TrTareaComentarios_ID), 13, 0, ".", "")));
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
         if ( cmbavCtrtareacomentarios_estado.ItemCount > 0 )
         {
            AV8cTrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbavCtrtareacomentarios_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8cTrTareaComentarios_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV8cTrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(AV8cTrTareaComentarios_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCtrtareacomentarios_estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8cTrTareaComentarios_Estado), 4, 0));
            AssignProp("", false, cmbavCtrtareacomentarios_estado_Internalname, "Values", cmbavCtrtareacomentarios_estado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF232( ) ;
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

      protected void RF232( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cTrTareaComentarios_IDTarea ,
                                                 AV8cTrTareaComentarios_Estado ,
                                                 AV9cTrTareaComentarios_FechaCreacion ,
                                                 AV10cTrTareaComentarios_FechaModificacion ,
                                                 A34TrTareaComentarios_IDTarea ,
                                                 A37TrTareaComentarios_Estado ,
                                                 A38TrTareaComentarios_FechaCreacion ,
                                                 A39TrTareaComentarios_FechaModificacion ,
                                                 AV6cTrTareaComentarios_ID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            } ) ;
            /* Using cursor H00232 */
            pr_default.execute(0, new Object[] {AV6cTrTareaComentarios_ID, AV7cTrTareaComentarios_IDTarea, AV8cTrTareaComentarios_Estado, AV9cTrTareaComentarios_FechaCreacion, AV10cTrTareaComentarios_FechaModificacion, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A39TrTareaComentarios_FechaModificacion = H00232_A39TrTareaComentarios_FechaModificacion[0];
               n39TrTareaComentarios_FechaModificacion = H00232_n39TrTareaComentarios_FechaModificacion[0];
               A38TrTareaComentarios_FechaCreacion = H00232_A38TrTareaComentarios_FechaCreacion[0];
               n38TrTareaComentarios_FechaCreacion = H00232_n38TrTareaComentarios_FechaCreacion[0];
               A37TrTareaComentarios_Estado = H00232_A37TrTareaComentarios_Estado[0];
               n37TrTareaComentarios_Estado = H00232_n37TrTareaComentarios_Estado[0];
               A34TrTareaComentarios_IDTarea = H00232_A34TrTareaComentarios_IDTarea[0];
               n34TrTareaComentarios_IDTarea = H00232_n34TrTareaComentarios_IDTarea[0];
               A35TrTareaComentarios_ID = H00232_A35TrTareaComentarios_ID[0];
               /* Execute user event: Load */
               E18232 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB230( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes232( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRTAREACOMENTARIOS_ID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A35TrTareaComentarios_ID), "ZZZZZZZZZZZZ9"), context));
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
                                              AV7cTrTareaComentarios_IDTarea ,
                                              AV8cTrTareaComentarios_Estado ,
                                              AV9cTrTareaComentarios_FechaCreacion ,
                                              AV10cTrTareaComentarios_FechaModificacion ,
                                              A34TrTareaComentarios_IDTarea ,
                                              A37TrTareaComentarios_Estado ,
                                              A38TrTareaComentarios_FechaCreacion ,
                                              A39TrTareaComentarios_FechaModificacion ,
                                              AV6cTrTareaComentarios_ID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         } ) ;
         /* Using cursor H00233 */
         pr_default.execute(1, new Object[] {AV6cTrTareaComentarios_ID, AV7cTrTareaComentarios_IDTarea, AV8cTrTareaComentarios_Estado, AV9cTrTareaComentarios_FechaCreacion, AV10cTrTareaComentarios_FechaModificacion});
         GRID1_nRecordCount = H00233_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareaComentarios_ID, AV7cTrTareaComentarios_IDTarea, AV8cTrTareaComentarios_Estado, AV9cTrTareaComentarios_FechaCreacion, AV10cTrTareaComentarios_FechaModificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareaComentarios_ID, AV7cTrTareaComentarios_IDTarea, AV8cTrTareaComentarios_Estado, AV9cTrTareaComentarios_FechaCreacion, AV10cTrTareaComentarios_FechaModificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareaComentarios_ID, AV7cTrTareaComentarios_IDTarea, AV8cTrTareaComentarios_Estado, AV9cTrTareaComentarios_FechaCreacion, AV10cTrTareaComentarios_FechaModificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareaComentarios_ID, AV7cTrTareaComentarios_IDTarea, AV8cTrTareaComentarios_Estado, AV9cTrTareaComentarios_FechaCreacion, AV10cTrTareaComentarios_FechaModificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareaComentarios_ID, AV7cTrTareaComentarios_IDTarea, AV8cTrTareaComentarios_Estado, AV9cTrTareaComentarios_FechaCreacion, AV10cTrTareaComentarios_FechaModificacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP230( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17232 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtrtareacomentarios_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtrtareacomentarios_id_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTRTAREACOMENTARIOS_ID");
               GX_FocusControl = edtavCtrtareacomentarios_id_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cTrTareaComentarios_ID = 0;
               AssignAttri("", false, "AV6cTrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(AV6cTrTareaComentarios_ID), 13, 0));
            }
            else
            {
               AV6cTrTareaComentarios_ID = (long)(context.localUtil.CToN( cgiGet( edtavCtrtareacomentarios_id_Internalname), ".", ","));
               AssignAttri("", false, "AV6cTrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(AV6cTrTareaComentarios_ID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtrtareacomentarios_idtarea_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtrtareacomentarios_idtarea_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTRTAREACOMENTARIOS_IDTAREA");
               GX_FocusControl = edtavCtrtareacomentarios_idtarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cTrTareaComentarios_IDTarea = 0;
               AssignAttri("", false, "AV7cTrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(AV7cTrTareaComentarios_IDTarea), 13, 0));
            }
            else
            {
               AV7cTrTareaComentarios_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtavCtrtareacomentarios_idtarea_Internalname), ".", ","));
               AssignAttri("", false, "AV7cTrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(AV7cTrTareaComentarios_IDTarea), 13, 0));
            }
            cmbavCtrtareacomentarios_estado.Name = cmbavCtrtareacomentarios_estado_Internalname;
            cmbavCtrtareacomentarios_estado.CurrentValue = cgiGet( cmbavCtrtareacomentarios_estado_Internalname);
            AV8cTrTareaComentarios_Estado = (short)(NumberUtil.Val( cgiGet( cmbavCtrtareacomentarios_estado_Internalname), "."));
            AssignAttri("", false, "AV8cTrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(AV8cTrTareaComentarios_Estado), 4, 0));
            if ( context.localUtil.VCDate( cgiGet( edtavCtrtareacomentarios_fechacreacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Tarea Comentarios_Fecha Creacion"}), 1, "vCTRTAREACOMENTARIOS_FECHACREACION");
               GX_FocusControl = edtavCtrtareacomentarios_fechacreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cTrTareaComentarios_FechaCreacion = DateTime.MinValue;
               AssignAttri("", false, "AV9cTrTareaComentarios_FechaCreacion", context.localUtil.Format(AV9cTrTareaComentarios_FechaCreacion, "99/99/9999"));
            }
            else
            {
               AV9cTrTareaComentarios_FechaCreacion = context.localUtil.CToD( cgiGet( edtavCtrtareacomentarios_fechacreacion_Internalname), 1);
               AssignAttri("", false, "AV9cTrTareaComentarios_FechaCreacion", context.localUtil.Format(AV9cTrTareaComentarios_FechaCreacion, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtrtareacomentarios_fechamodificacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Tarea Comentarios_Fecha Modificacion"}), 1, "vCTRTAREACOMENTARIOS_FECHAMODIFICACION");
               GX_FocusControl = edtavCtrtareacomentarios_fechamodificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cTrTareaComentarios_FechaModificacion = DateTime.MinValue;
               AssignAttri("", false, "AV10cTrTareaComentarios_FechaModificacion", context.localUtil.Format(AV10cTrTareaComentarios_FechaModificacion, "99/99/9999"));
            }
            else
            {
               AV10cTrTareaComentarios_FechaModificacion = context.localUtil.CToD( cgiGet( edtavCtrtareacomentarios_fechamodificacion_Internalname), 1);
               AssignAttri("", false, "AV10cTrTareaComentarios_FechaModificacion", context.localUtil.Format(AV10cTrTareaComentarios_FechaModificacion, "99/99/9999"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREACOMENTARIOS_ID"), ".", ",") != Convert.ToDecimal( AV6cTrTareaComentarios_ID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREACOMENTARIOS_IDTAREA"), ".", ",") != Convert.ToDecimal( AV7cTrTareaComentarios_IDTarea )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREACOMENTARIOS_ESTADO"), ".", ",") != Convert.ToDecimal( AV8cTrTareaComentarios_Estado )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRTAREACOMENTARIOS_FECHACREACION"), 1) != AV9cTrTareaComentarios_FechaCreacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTRTAREACOMENTARIOS_FECHAMODIFICACION"), 1) != AV10cTrTareaComentarios_FechaModificacion )
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
         E17232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17232( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Selection List %1", "Tr Tarea Comentarios", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E18232( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV15Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            context.DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E19232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19232( )
      {
         /* Enter Routine */
         AV11pTrTareaComentarios_ID = A35TrTareaComentarios_ID;
         AssignAttri("", false, "AV11pTrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(AV11pTrTareaComentarios_ID), 13, 0));
         context.setWebReturnParms(new Object[] {(long)AV11pTrTareaComentarios_ID});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pTrTareaComentarios_ID"});
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
         AV11pTrTareaComentarios_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV11pTrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(AV11pTrTareaComentarios_ID), 13, 0));
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
         PA232( ) ;
         WS232( ) ;
         WE232( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210202136512", true, true);
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
         context.AddJavascriptSource("gx0050.js", "?202210202136513", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtTrTareaComentarios_ID_Internalname = "TRTAREACOMENTARIOS_ID_"+sGXsfl_64_idx;
         edtTrTareaComentarios_IDTarea_Internalname = "TRTAREACOMENTARIOS_IDTAREA_"+sGXsfl_64_idx;
         cmbTrTareaComentarios_Estado_Internalname = "TRTAREACOMENTARIOS_ESTADO_"+sGXsfl_64_idx;
         edtTrTareaComentarios_FechaCreacion_Internalname = "TRTAREACOMENTARIOS_FECHACREACION_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtTrTareaComentarios_ID_Internalname = "TRTAREACOMENTARIOS_ID_"+sGXsfl_64_fel_idx;
         edtTrTareaComentarios_IDTarea_Internalname = "TRTAREACOMENTARIOS_IDTAREA_"+sGXsfl_64_fel_idx;
         cmbTrTareaComentarios_Estado_Internalname = "TRTAREACOMENTARIOS_ESTADO_"+sGXsfl_64_fel_idx;
         edtTrTareaComentarios_FechaCreacion_Internalname = "TRTAREACOMENTARIOS_FECHACREACION_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB230( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A35TrTareaComentarios_ID), 13, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV15Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)sImgUrl,(String)edtavLinkselection_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWActionColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A35TrTareaComentarios_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A35TrTareaComentarios_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_ID_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_IDTarea_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A34TrTareaComentarios_IDTarea), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_IDTarea_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbTrTareaComentarios_Estado.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "TRTAREACOMENTARIOS_ESTADO_" + sGXsfl_64_idx;
               cmbTrTareaComentarios_Estado.Name = GXCCtl;
               cmbTrTareaComentarios_Estado.WebTags = "";
               cmbTrTareaComentarios_Estado.addItem("1", "Activo", 0);
               cmbTrTareaComentarios_Estado.addItem("2", "Inactivo", 0);
               cmbTrTareaComentarios_Estado.addItem("3", "Eliminado", 0);
               if ( cmbTrTareaComentarios_Estado.ItemCount > 0 )
               {
                  A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbTrTareaComentarios_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0))), "."));
                  n37TrTareaComentarios_Estado = false;
               }
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbTrTareaComentarios_Estado,(String)cmbTrTareaComentarios_Estado_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0)),(short)1,(String)cmbTrTareaComentarios_Estado_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"int",(String)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(String)"px",(short)0,(String)"px",(String)"",(String)"DescriptionAttribute",(String)"WWColumn",(String)"",(String)"",(String)"",(bool)true});
            cmbTrTareaComentarios_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
            AssignProp("", false, cmbTrTareaComentarios_Estado_Internalname, "Values", (String)(cmbTrTareaComentarios_Estado.ToJavascriptSource()), !bGXsfl_64_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareaComentarios_FechaCreacion_Internalname,context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"),context.localUtil.Format( A38TrTareaComentarios_FechaCreacion, "99/99/9999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareaComentarios_FechaCreacion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)64,(short)1,(short)-1,(short)0,(bool)true,(String)"FechaCompleta",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes232( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         cmbavCtrtareacomentarios_estado.Name = "vCTRTAREACOMENTARIOS_ESTADO";
         cmbavCtrtareacomentarios_estado.WebTags = "";
         cmbavCtrtareacomentarios_estado.addItem("1", "Activo", 0);
         cmbavCtrtareacomentarios_estado.addItem("2", "Inactivo", 0);
         cmbavCtrtareacomentarios_estado.addItem("3", "Eliminado", 0);
         if ( cmbavCtrtareacomentarios_estado.ItemCount > 0 )
         {
            AV8cTrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbavCtrtareacomentarios_estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8cTrTareaComentarios_Estado), 4, 0))), "."));
            AssignAttri("", false, "AV8cTrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(AV8cTrTareaComentarios_Estado), 4, 0));
         }
         GXCCtl = "TRTAREACOMENTARIOS_ESTADO_" + sGXsfl_64_idx;
         cmbTrTareaComentarios_Estado.Name = GXCCtl;
         cmbTrTareaComentarios_Estado.WebTags = "";
         cmbTrTareaComentarios_Estado.addItem("1", "Activo", 0);
         cmbTrTareaComentarios_Estado.addItem("2", "Inactivo", 0);
         cmbTrTareaComentarios_Estado.addItem("3", "Eliminado", 0);
         if ( cmbTrTareaComentarios_Estado.ItemCount > 0 )
         {
            A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbTrTareaComentarios_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0))), "."));
            n37TrTareaComentarios_Estado = false;
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLbltrtareacomentarios_idfilter_Internalname = "LBLTRTAREACOMENTARIOS_IDFILTER";
         edtavCtrtareacomentarios_id_Internalname = "vCTRTAREACOMENTARIOS_ID";
         divTrtareacomentarios_idfiltercontainer_Internalname = "TRTAREACOMENTARIOS_IDFILTERCONTAINER";
         lblLbltrtareacomentarios_idtareafilter_Internalname = "LBLTRTAREACOMENTARIOS_IDTAREAFILTER";
         edtavCtrtareacomentarios_idtarea_Internalname = "vCTRTAREACOMENTARIOS_IDTAREA";
         divTrtareacomentarios_idtareafiltercontainer_Internalname = "TRTAREACOMENTARIOS_IDTAREAFILTERCONTAINER";
         lblLbltrtareacomentarios_estadofilter_Internalname = "LBLTRTAREACOMENTARIOS_ESTADOFILTER";
         cmbavCtrtareacomentarios_estado_Internalname = "vCTRTAREACOMENTARIOS_ESTADO";
         divTrtareacomentarios_estadofiltercontainer_Internalname = "TRTAREACOMENTARIOS_ESTADOFILTERCONTAINER";
         lblLbltrtareacomentarios_fechacreacionfilter_Internalname = "LBLTRTAREACOMENTARIOS_FECHACREACIONFILTER";
         edtavCtrtareacomentarios_fechacreacion_Internalname = "vCTRTAREACOMENTARIOS_FECHACREACION";
         divTrtareacomentarios_fechacreacionfiltercontainer_Internalname = "TRTAREACOMENTARIOS_FECHACREACIONFILTERCONTAINER";
         lblLbltrtareacomentarios_fechamodificacionfilter_Internalname = "LBLTRTAREACOMENTARIOS_FECHAMODIFICACIONFILTER";
         edtavCtrtareacomentarios_fechamodificacion_Internalname = "vCTRTAREACOMENTARIOS_FECHAMODIFICACION";
         divTrtareacomentarios_fechamodificacionfiltercontainer_Internalname = "TRTAREACOMENTARIOS_FECHAMODIFICACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTrTareaComentarios_ID_Internalname = "TRTAREACOMENTARIOS_ID";
         edtTrTareaComentarios_IDTarea_Internalname = "TRTAREACOMENTARIOS_IDTAREA";
         cmbTrTareaComentarios_Estado_Internalname = "TRTAREACOMENTARIOS_ESTADO";
         edtTrTareaComentarios_FechaCreacion_Internalname = "TRTAREACOMENTARIOS_FECHACREACION";
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
         edtTrTareaComentarios_FechaCreacion_Jsonclick = "";
         cmbTrTareaComentarios_Estado_Jsonclick = "";
         edtTrTareaComentarios_IDTarea_Jsonclick = "";
         edtTrTareaComentarios_ID_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         cmbTrTareaComentarios_Estado.Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCtrtareacomentarios_fechamodificacion_Jsonclick = "";
         edtavCtrtareacomentarios_fechamodificacion_Enabled = 1;
         edtavCtrtareacomentarios_fechacreacion_Jsonclick = "";
         edtavCtrtareacomentarios_fechacreacion_Enabled = 1;
         cmbavCtrtareacomentarios_estado_Jsonclick = "";
         cmbavCtrtareacomentarios_estado.Enabled = 1;
         cmbavCtrtareacomentarios_estado.Visible = 1;
         edtavCtrtareacomentarios_idtarea_Jsonclick = "";
         edtavCtrtareacomentarios_idtarea_Enabled = 1;
         edtavCtrtareacomentarios_idtarea_Visible = 1;
         edtavCtrtareacomentarios_id_Jsonclick = "";
         edtavCtrtareacomentarios_id_Enabled = 1;
         edtavCtrtareacomentarios_id_Visible = 1;
         divTrtareacomentarios_fechamodificacionfiltercontainer_Class = "AdvancedContainerItem";
         divTrtareacomentarios_fechacreacionfiltercontainer_Class = "AdvancedContainerItem";
         divTrtareacomentarios_estadofiltercontainer_Class = "AdvancedContainerItem";
         divTrtareacomentarios_idtareafiltercontainer_Class = "AdvancedContainerItem";
         divTrtareacomentarios_idfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Tr Tarea Comentarios";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareaComentarios_ID',fld:'vCTRTAREACOMENTARIOS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrTareaComentarios_IDTarea',fld:'vCTRTAREACOMENTARIOS_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'cmbavCtrtareacomentarios_estado'},{av:'AV8cTrTareaComentarios_Estado',fld:'vCTRTAREACOMENTARIOS_ESTADO',pic:'ZZZ9'},{av:'AV9cTrTareaComentarios_FechaCreacion',fld:'vCTRTAREACOMENTARIOS_FECHACREACION',pic:''},{av:'AV10cTrTareaComentarios_FechaModificacion',fld:'vCTRTAREACOMENTARIOS_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16231',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLTRTAREACOMENTARIOS_IDFILTER.CLICK","{handler:'E11231',iparms:[{av:'divTrtareacomentarios_idfiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_IDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRTAREACOMENTARIOS_IDFILTER.CLICK",",oparms:[{av:'divTrtareacomentarios_idfiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_IDFILTERCONTAINER',prop:'Class'},{av:'edtavCtrtareacomentarios_id_Visible',ctrl:'vCTRTAREACOMENTARIOS_ID',prop:'Visible'}]}");
         setEventMetadata("LBLTRTAREACOMENTARIOS_IDTAREAFILTER.CLICK","{handler:'E12231',iparms:[{av:'divTrtareacomentarios_idtareafiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_IDTAREAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRTAREACOMENTARIOS_IDTAREAFILTER.CLICK",",oparms:[{av:'divTrtareacomentarios_idtareafiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_IDTAREAFILTERCONTAINER',prop:'Class'},{av:'edtavCtrtareacomentarios_idtarea_Visible',ctrl:'vCTRTAREACOMENTARIOS_IDTAREA',prop:'Visible'}]}");
         setEventMetadata("LBLTRTAREACOMENTARIOS_ESTADOFILTER.CLICK","{handler:'E13231',iparms:[{av:'divTrtareacomentarios_estadofiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_ESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRTAREACOMENTARIOS_ESTADOFILTER.CLICK",",oparms:[{av:'divTrtareacomentarios_estadofiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_ESTADOFILTERCONTAINER',prop:'Class'},{av:'cmbavCtrtareacomentarios_estado'}]}");
         setEventMetadata("LBLTRTAREACOMENTARIOS_FECHACREACIONFILTER.CLICK","{handler:'E14231',iparms:[{av:'divTrtareacomentarios_fechacreacionfiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_FECHACREACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRTAREACOMENTARIOS_FECHACREACIONFILTER.CLICK",",oparms:[{av:'divTrtareacomentarios_fechacreacionfiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_FECHACREACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLTRTAREACOMENTARIOS_FECHAMODIFICACIONFILTER.CLICK","{handler:'E15231',iparms:[{av:'divTrtareacomentarios_fechamodificacionfiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRTAREACOMENTARIOS_FECHAMODIFICACIONFILTER.CLICK",",oparms:[{av:'divTrtareacomentarios_fechamodificacionfiltercontainer_Class',ctrl:'TRTAREACOMENTARIOS_FECHAMODIFICACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("ENTER","{handler:'E19232',iparms:[{av:'A35TrTareaComentarios_ID',fld:'TRTAREACOMENTARIOS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pTrTareaComentarios_ID',fld:'vPTRTAREACOMENTARIOS_ID',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareaComentarios_ID',fld:'vCTRTAREACOMENTARIOS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrTareaComentarios_IDTarea',fld:'vCTRTAREACOMENTARIOS_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'cmbavCtrtareacomentarios_estado'},{av:'AV8cTrTareaComentarios_Estado',fld:'vCTRTAREACOMENTARIOS_ESTADO',pic:'ZZZ9'},{av:'AV9cTrTareaComentarios_FechaCreacion',fld:'vCTRTAREACOMENTARIOS_FECHACREACION',pic:''},{av:'AV10cTrTareaComentarios_FechaModificacion',fld:'vCTRTAREACOMENTARIOS_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareaComentarios_ID',fld:'vCTRTAREACOMENTARIOS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrTareaComentarios_IDTarea',fld:'vCTRTAREACOMENTARIOS_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'cmbavCtrtareacomentarios_estado'},{av:'AV8cTrTareaComentarios_Estado',fld:'vCTRTAREACOMENTARIOS_ESTADO',pic:'ZZZ9'},{av:'AV9cTrTareaComentarios_FechaCreacion',fld:'vCTRTAREACOMENTARIOS_FECHACREACION',pic:''},{av:'AV10cTrTareaComentarios_FechaModificacion',fld:'vCTRTAREACOMENTARIOS_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareaComentarios_ID',fld:'vCTRTAREACOMENTARIOS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrTareaComentarios_IDTarea',fld:'vCTRTAREACOMENTARIOS_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'cmbavCtrtareacomentarios_estado'},{av:'AV8cTrTareaComentarios_Estado',fld:'vCTRTAREACOMENTARIOS_ESTADO',pic:'ZZZ9'},{av:'AV9cTrTareaComentarios_FechaCreacion',fld:'vCTRTAREACOMENTARIOS_FECHACREACION',pic:''},{av:'AV10cTrTareaComentarios_FechaModificacion',fld:'vCTRTAREACOMENTARIOS_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareaComentarios_ID',fld:'vCTRTAREACOMENTARIOS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV7cTrTareaComentarios_IDTarea',fld:'vCTRTAREACOMENTARIOS_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'cmbavCtrtareacomentarios_estado'},{av:'AV8cTrTareaComentarios_Estado',fld:'vCTRTAREACOMENTARIOS_ESTADO',pic:'ZZZ9'},{av:'AV9cTrTareaComentarios_FechaCreacion',fld:'vCTRTAREACOMENTARIOS_FECHACREACION',pic:''},{av:'AV10cTrTareaComentarios_FechaModificacion',fld:'vCTRTAREACOMENTARIOS_FECHAMODIFICACION',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CTRTAREACOMENTARIOS_ESTADO","{handler:'Validv_Ctrtareacomentarios_estado',iparms:[]");
         setEventMetadata("VALIDV_CTRTAREACOMENTARIOS_ESTADO",",oparms:[]}");
         setEventMetadata("VALIDV_CTRTAREACOMENTARIOS_FECHACREACION","{handler:'Validv_Ctrtareacomentarios_fechacreacion',iparms:[]");
         setEventMetadata("VALIDV_CTRTAREACOMENTARIOS_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALIDV_CTRTAREACOMENTARIOS_FECHAMODIFICACION","{handler:'Validv_Ctrtareacomentarios_fechamodificacion',iparms:[]");
         setEventMetadata("VALIDV_CTRTAREACOMENTARIOS_FECHAMODIFICACION",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Trtareacomentarios_fechacreacion',iparms:[]");
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
         AV9cTrTareaComentarios_FechaCreacion = DateTime.MinValue;
         AV10cTrTareaComentarios_FechaModificacion = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbltrtareacomentarios_idfilter_Jsonclick = "";
         TempTags = "";
         lblLbltrtareacomentarios_idtareafilter_Jsonclick = "";
         lblLbltrtareacomentarios_estadofilter_Jsonclick = "";
         lblLbltrtareacomentarios_fechacreacionfilter_Jsonclick = "";
         lblLbltrtareacomentarios_fechamodificacionfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A38TrTareaComentarios_FechaCreacion = DateTime.MinValue;
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV15Linkselection_GXI = "";
         scmdbuf = "";
         A39TrTareaComentarios_FechaModificacion = DateTime.MinValue;
         H00232_A39TrTareaComentarios_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         H00232_n39TrTareaComentarios_FechaModificacion = new bool[] {false} ;
         H00232_A38TrTareaComentarios_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         H00232_n38TrTareaComentarios_FechaCreacion = new bool[] {false} ;
         H00232_A37TrTareaComentarios_Estado = new short[1] ;
         H00232_n37TrTareaComentarios_Estado = new bool[] {false} ;
         H00232_A34TrTareaComentarios_IDTarea = new long[1] ;
         H00232_n34TrTareaComentarios_IDTarea = new bool[] {false} ;
         H00232_A35TrTareaComentarios_ID = new long[1] ;
         H00233_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0050__default(),
            new Object[][] {
                new Object[] {
               H00232_A39TrTareaComentarios_FechaModificacion, H00232_n39TrTareaComentarios_FechaModificacion, H00232_A38TrTareaComentarios_FechaCreacion, H00232_n38TrTareaComentarios_FechaCreacion, H00232_A37TrTareaComentarios_Estado, H00232_n37TrTareaComentarios_Estado, H00232_A34TrTareaComentarios_IDTarea, H00232_n34TrTareaComentarios_IDTarea, H00232_A35TrTareaComentarios_ID
               }
               , new Object[] {
               H00233_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV8cTrTareaComentarios_Estado ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A37TrTareaComentarios_Estado ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_64 ;
      private int nGXsfl_64_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCtrtareacomentarios_id_Enabled ;
      private int edtavCtrtareacomentarios_id_Visible ;
      private int edtavCtrtareacomentarios_idtarea_Enabled ;
      private int edtavCtrtareacomentarios_idtarea_Visible ;
      private int edtavCtrtareacomentarios_fechacreacion_Enabled ;
      private int edtavCtrtareacomentarios_fechamodificacion_Enabled ;
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
      private long AV6cTrTareaComentarios_ID ;
      private long AV7cTrTareaComentarios_IDTarea ;
      private long AV11pTrTareaComentarios_ID ;
      private long A35TrTareaComentarios_ID ;
      private long A34TrTareaComentarios_IDTarea ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private String divAdvancedcontainer_Class ;
      private String bttBtntoggle_Class ;
      private String divTrtareacomentarios_idfiltercontainer_Class ;
      private String divTrtareacomentarios_idtareafiltercontainer_Class ;
      private String divTrtareacomentarios_estadofiltercontainer_Class ;
      private String divTrtareacomentarios_fechacreacionfiltercontainer_Class ;
      private String divTrtareacomentarios_fechamodificacionfiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_64_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMain_Internalname ;
      private String divAdvancedcontainer_Internalname ;
      private String divTrtareacomentarios_idfiltercontainer_Internalname ;
      private String lblLbltrtareacomentarios_idfilter_Internalname ;
      private String lblLbltrtareacomentarios_idfilter_Jsonclick ;
      private String edtavCtrtareacomentarios_id_Internalname ;
      private String TempTags ;
      private String edtavCtrtareacomentarios_id_Jsonclick ;
      private String divTrtareacomentarios_idtareafiltercontainer_Internalname ;
      private String lblLbltrtareacomentarios_idtareafilter_Internalname ;
      private String lblLbltrtareacomentarios_idtareafilter_Jsonclick ;
      private String edtavCtrtareacomentarios_idtarea_Internalname ;
      private String edtavCtrtareacomentarios_idtarea_Jsonclick ;
      private String divTrtareacomentarios_estadofiltercontainer_Internalname ;
      private String lblLbltrtareacomentarios_estadofilter_Internalname ;
      private String lblLbltrtareacomentarios_estadofilter_Jsonclick ;
      private String cmbavCtrtareacomentarios_estado_Internalname ;
      private String cmbavCtrtareacomentarios_estado_Jsonclick ;
      private String divTrtareacomentarios_fechacreacionfiltercontainer_Internalname ;
      private String lblLbltrtareacomentarios_fechacreacionfilter_Internalname ;
      private String lblLbltrtareacomentarios_fechacreacionfilter_Jsonclick ;
      private String edtavCtrtareacomentarios_fechacreacion_Internalname ;
      private String edtavCtrtareacomentarios_fechacreacion_Jsonclick ;
      private String divTrtareacomentarios_fechamodificacionfiltercontainer_Internalname ;
      private String lblLbltrtareacomentarios_fechamodificacionfilter_Internalname ;
      private String lblLbltrtareacomentarios_fechamodificacionfilter_Jsonclick ;
      private String edtavCtrtareacomentarios_fechamodificacion_Internalname ;
      private String edtavCtrtareacomentarios_fechamodificacion_Jsonclick ;
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
      private String edtTrTareaComentarios_ID_Internalname ;
      private String edtTrTareaComentarios_IDTarea_Internalname ;
      private String cmbTrTareaComentarios_Estado_Internalname ;
      private String edtTrTareaComentarios_FechaCreacion_Internalname ;
      private String scmdbuf ;
      private String AV12ADVANCED_LABEL_TEMPLATE ;
      private String sGXsfl_64_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtTrTareaComentarios_ID_Jsonclick ;
      private String edtTrTareaComentarios_IDTarea_Jsonclick ;
      private String GXCCtl ;
      private String cmbTrTareaComentarios_Estado_Jsonclick ;
      private String edtTrTareaComentarios_FechaCreacion_Jsonclick ;
      private DateTime AV9cTrTareaComentarios_FechaCreacion ;
      private DateTime AV10cTrTareaComentarios_FechaModificacion ;
      private DateTime A38TrTareaComentarios_FechaCreacion ;
      private DateTime A39TrTareaComentarios_FechaModificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool n34TrTareaComentarios_IDTarea ;
      private bool n37TrTareaComentarios_Estado ;
      private bool n38TrTareaComentarios_FechaCreacion ;
      private bool gxdyncontrolsrefreshing ;
      private bool n39TrTareaComentarios_FechaModificacion ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private String AV15Linkselection_GXI ;
      private String AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCtrtareacomentarios_estado ;
      private GXCombobox cmbTrTareaComentarios_Estado ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H00232_A39TrTareaComentarios_FechaModificacion ;
      private bool[] H00232_n39TrTareaComentarios_FechaModificacion ;
      private DateTime[] H00232_A38TrTareaComentarios_FechaCreacion ;
      private bool[] H00232_n38TrTareaComentarios_FechaCreacion ;
      private short[] H00232_A37TrTareaComentarios_Estado ;
      private bool[] H00232_n37TrTareaComentarios_Estado ;
      private long[] H00232_A34TrTareaComentarios_IDTarea ;
      private bool[] H00232_n34TrTareaComentarios_IDTarea ;
      private long[] H00232_A35TrTareaComentarios_ID ;
      private long[] H00233_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pTrTareaComentarios_ID ;
      private GXWebForm Form ;
   }

   public class gx0050__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00232( IGxContext context ,
                                             long AV7cTrTareaComentarios_IDTarea ,
                                             short AV8cTrTareaComentarios_Estado ,
                                             DateTime AV9cTrTareaComentarios_FechaCreacion ,
                                             DateTime AV10cTrTareaComentarios_FechaModificacion ,
                                             long A34TrTareaComentarios_IDTarea ,
                                             short A37TrTareaComentarios_Estado ,
                                             DateTime A38TrTareaComentarios_FechaCreacion ,
                                             DateTime A39TrTareaComentarios_FechaModificacion ,
                                             long AV6cTrTareaComentarios_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [8] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [TrTareaComentarios_FechaModificacion], [TrTareaComentarios_FechaCreacion], [TrTareaComentarios_Estado], [TrTareaComentarios_IDTarea], [TrTareaComentarios_ID]";
         sFromString = " FROM TABLERO.[TrTareaComentarios]";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE ([TrTareaComentarios_ID] >= @AV6cTrTareaComentarios_ID)";
         if ( ! (0==AV7cTrTareaComentarios_IDTarea) )
         {
            sWhereString = sWhereString + " and ([TrTareaComentarios_IDTarea] >= @AV7cTrTareaComentarios_IDTarea)";
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cTrTareaComentarios_Estado) )
         {
            sWhereString = sWhereString + " and ([TrTareaComentarios_Estado] >= @AV8cTrTareaComentarios_Estado)";
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTrTareaComentarios_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrTareaComentarios_FechaCreacion] >= @AV9cTrTareaComentarios_FechaCreacion)";
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cTrTareaComentarios_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrTareaComentarios_FechaModificacion] >= @AV10cTrTareaComentarios_FechaModificacion)";
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString = sOrderString + " ORDER BY [TrTareaComentarios_ID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00233( IGxContext context ,
                                             long AV7cTrTareaComentarios_IDTarea ,
                                             short AV8cTrTareaComentarios_Estado ,
                                             DateTime AV9cTrTareaComentarios_FechaCreacion ,
                                             DateTime AV10cTrTareaComentarios_FechaModificacion ,
                                             long A34TrTareaComentarios_IDTarea ,
                                             short A37TrTareaComentarios_Estado ,
                                             DateTime A38TrTareaComentarios_FechaCreacion ,
                                             DateTime A39TrTareaComentarios_FechaModificacion ,
                                             long AV6cTrTareaComentarios_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [5] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM TABLERO.[TrTareaComentarios]";
         scmdbuf = scmdbuf + " WHERE ([TrTareaComentarios_ID] >= @AV6cTrTareaComentarios_ID)";
         if ( ! (0==AV7cTrTareaComentarios_IDTarea) )
         {
            sWhereString = sWhereString + " and ([TrTareaComentarios_IDTarea] >= @AV7cTrTareaComentarios_IDTarea)";
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cTrTareaComentarios_Estado) )
         {
            sWhereString = sWhereString + " and ([TrTareaComentarios_Estado] >= @AV8cTrTareaComentarios_Estado)";
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTrTareaComentarios_FechaCreacion) )
         {
            sWhereString = sWhereString + " and ([TrTareaComentarios_FechaCreacion] >= @AV9cTrTareaComentarios_FechaCreacion)";
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cTrTareaComentarios_FechaModificacion) )
         {
            sWhereString = sWhereString + " and ([TrTareaComentarios_FechaModificacion] >= @AV10cTrTareaComentarios_FechaModificacion)";
         }
         else
         {
            GXv_int3[4] = 1;
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
                     return conditional_H00232(context, (long)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] );
               case 1 :
                     return conditional_H00233(context, (long)dynConstraints[0] , (short)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (long)dynConstraints[4] , (short)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] );
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
          Object[] prmH00232 ;
          prmH00232 = new Object[] {
          new Object[] {"@AV6cTrTareaComentarios_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV7cTrTareaComentarios_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV8cTrTareaComentarios_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@AV9cTrTareaComentarios_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV10cTrTareaComentarios_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00233 ;
          prmH00233 = new Object[] {
          new Object[] {"@AV6cTrTareaComentarios_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV7cTrTareaComentarios_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV8cTrTareaComentarios_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@AV9cTrTareaComentarios_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@AV10cTrTareaComentarios_FechaModificacion",SqlDbType.DateTime,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00232", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00232,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00233", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00233,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5) ;
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
                   stmt.SetParameter(sIdx, (long)parms[8]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[9]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[10]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[11]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[12]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[13]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[14]);
                }
                if ( (short)parms[7] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[15]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[5]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[6]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[7]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[8]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (DateTime)parms[9]);
                }
                return;
       }
    }

 }

}
