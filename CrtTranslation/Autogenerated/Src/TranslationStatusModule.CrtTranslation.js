 define("TranslationStatusModule", ["ext-base", "BaseModule"], function(Ext, NetworkUtilities) {
    Ext.define("Terrasoft.configuration.TranslationStatusModule", {
      extend: "Terrasoft.BaseModule",
      alternateClassName: "Terrasoft.TranslationStatusModule",
       messages: {
		   "PushHistoryState": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
       },
       init: function() {
           this.sandbox.registerMessages(this.messages);
		   this.sandbox.publish("PushHistoryState", {
						hash: "Page/TranslationStatusPage"
					});
         this.callParent(arguments);
      },
   });
   return Terrasoft.TranslationStatusModule;
});