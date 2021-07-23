gx.evt.autoSkip = false;
gx.define('recentlinks', true, function (CmpContext) {
   this.ServerClass =  "recentlinks" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "recentlinks.aspx" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV6FormCaption=gx.fn.getControlValue("vFORMCAPTION") ;
      this.AV7FormPgmName=gx.fn.getControlValue("vFORMPGMNAME") ;
      this.AV6FormCaption=gx.fn.getControlValue("vFORMCAPTION") ;
   };
   this.e13022_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e14022_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,5,10,12,14];
   this.GXLastCtrlId =14;
   this.LinksContainer = new gx.grid.grid(this, 2,"WbpLvl2",7,"Links","Links","LinksContainer",this.CmpContext,this.IsMasterPage,"recentlinks",[],true,0,false,true,0,false,false,false,"",0,"px",0,"px","Novo registro",false,false,false,null,null,false,"",false,[1,1,1,1],false,0,false,false);
   var LinksContainer = this.LinksContainer;
   LinksContainer.startRow("","","","","","");
   LinksContainer.startCell("","","","","","","37px","","","");
   LinksContainer.addTextBlock('PLACE',null,10);
   LinksContainer.endCell();
   LinksContainer.startCell("","","","","","","4px","","","td100");
   LinksContainer.addTextBlock('PIPE',null,12);
   LinksContainer.endCell();
   LinksContainer.endRow();
   this.LinksContainer.emptyText = "";
   this.setGrid(LinksContainer);
   GXValidFnc[2]={ id: 2, fld:"TABLE",grid:0};
   GXValidFnc[5]={ id: 5, fld:"RECENTTEXT", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[10]={ id: 10, fld:"PLACE", format:0,grid:7, ctrltype: "textblock"};
   GXValidFnc[12]={ id: 12, fld:"PIPE", format:0,grid:7, ctrltype: "textblock"};
   GXValidFnc[14]={ id: 14, fld:"BOTTOMLINE",grid:0};
   this.AV6FormCaption = "" ;
   this.AV7FormPgmName = "" ;
   this.Events = {"e13022_client": ["ENTER", true] ,"e14022_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'LINKS_nFirstRecordOnPage'},{av:'LINKS_nEOF'},{av:'AV6FormCaption',fld:'vFORMCAPTION',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["START"] = [[],[{av:'gx.fn.getCtrlProperty("PIPE","Caption")',ctrl:'PIPE',prop:'Caption'}]];
   this.EvtParms["LINKS.LOAD"] = [[{av:'AV6FormCaption',fld:'vFORMCAPTION',pic:''}],[{av:'gx.fn.getCtrlProperty("PLACE","Caption")',ctrl:'PLACE',prop:'Caption'},{av:'gx.fn.getCtrlProperty("PLACE","Link")',ctrl:'PLACE',prop:'Link'}]];
   this.setVCMap("AV6FormCaption", "vFORMCAPTION", 0, "char", 100, 0);
   this.setVCMap("AV7FormPgmName", "vFORMPGMNAME", 0, "svchar", 256, 0);
   this.setVCMap("AV6FormCaption", "vFORMCAPTION", 0, "char", 100, 0);
   this.setVCMap("AV6FormCaption", "vFORMCAPTION", 0, "char", 100, 0);
   LinksContainer.addRefreshingVar({rfrVar:"AV6FormCaption"});
   LinksContainer.addRefreshingParm({rfrVar:"AV6FormCaption"});
   this.Initialize( );
});
