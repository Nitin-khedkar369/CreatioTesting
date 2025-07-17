define("AIEmbeddedPanel", /**SCHEMA_DEPS*/["@creatio-devkit/common", "css!AIEmbeddedPanelStyles"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(sdk)/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "remove",
				"name": "MainHeader"
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"padding": {
						"top": "none",
						"bottom": "none",
						"right": "none",
						"left": "extra-small"
					}
				}
			},
			{
				"operation": "insert",
				"name": "EmbeddedHeader",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"classes": [
						"embedded-header"
					],
					"justifyContent": "space-between",
					"items": [
						{
							"type": "crt.FlexContainer",
							"direction": "row",
							"alignItems": "center",
							"classes": [
								"max-width"
							],
							"justifyContent": "space-between",
							"items": [
								{
									"type": "crt.FlexContainer",
									"direction": "row",
									"gap": "10",
									"alignItems": "center",
									"items": [
										{
											"type": "crt.Button",
											"icon": "back-button-icon",
											"iconPosition": "only-icon",
											"visible": "$IsHeaderCaptionVisible",
											"labelType": "body-1",
											"title": "#ResourceString(GoBackToListButton_title)#",
											"color": "default",
											"size": "medium",
											"clicked": {
												"request": "crt.ChatListOpenRequest",
												"params": {}
											}
										},
										{
											"type": "crt.Label",
											"caption": "$CurrentCopilotSessionTitle",
											"visible": "$IsHeaderCaptionVisible",
											"labelType": "body-large",
											"labelThickness": "default",
											"labelTextAlign": "start"
										}
									]
								},
								{
									"type": "crt.FlexContainer",
									"name": "LogoutButtonContainer",
									"direction": "row",
									"items": [
										{
											"type": "crt.Button",
											"icon": "edit-button-icon",
											"size": "medium",
											"iconPosition": "only-icon",
											"title": "#ResourceString(NewChatButton_caption)#",
											"clicked": {
												"request": "crt.CopilotNewChatRequest",
												"params": {
													"chatMessagesAttributeName": "ChatMessages",
													"sessionIdAttributeName": "CurrentCopilotSessionId",
													"sessionTitleAttributeName": "CurrentCopilotSessionTitle",
													"conversationEventAttributeName": "ConversationEvent"
												}
											},
											"color": "default",
											"disabled": "$IsCopilotDisclaimerVisible",
											"visible": true,
											"caption": "#ResourceString(NewChatButton_caption)#",
											"clickMode": "default"
										},
										{
											"type": "crt.Button",
											"icon": "more-button-icon",
											"iconPosition": "only-icon",
											"color": "default",
											"size": "medium",
											"clickMode": "menu",
											"menuItems": [
												{
													"type": "crt.MenuItem",
													"caption": "#ResourceString(AiEmbedded_Logout_Button_Caption)#",
													"color": "default",
													"disabled": false,
													"size": "medium",
													"iconPosition": "left-icon",
													"icon": "go-out-icon",
													"clicked": {
														"request": "crt.AiEmbeddedLogoutRequest"
													},
													"clickMode": "default"
												}
											],
											"visible": true
										}
									]
								}
							]
						}
					]
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "Conversation",
				"values": {
					"isEmbeddedMode": true
				}
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"IsHeaderCaptionVisible": {
						"from": [
							"IsCombinedMode",
							"ChatsListVisible"
						],
						"converter": "crt.CreatioAiHeaderCaption : false"
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});