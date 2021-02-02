// ===================================================================================================
//                           _  __     _ _
//                          | |/ /__ _| | |_ _  _ _ _ __ _
//                          | ' </ _` | |  _| || | '_/ _` |
//                          |_|\_\__,_|_|\__|\_,_|_| \__,_|
//
// This file is part of the Kaltura Collaborative Media Suite which allows users
// to do with audio, video, and animation what Wiki platfroms allow them to do with
// text.
//
// Copyright (C) 2006-2021  Kaltura Inc.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// @ignore
// ===================================================================================================
using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using Kaltura.Request;
using Kaltura.Types;
using Kaltura.Enums;
using Newtonsoft.Json.Linq;

namespace Kaltura.Services
{
// BEO-9522 csharp2 before comment
	public class MessageTemplateGetRequestBuilder : RequestBuilder<MessageTemplate>
	{
		#region Constants
		public const string MESSAGE_TYPE = "messageType";
		#endregion

		public MessageTemplateType MessageType { get; set; }

		public MessageTemplateGetRequestBuilder()
			: base("messagetemplate", "get")
		{
		}

		public MessageTemplateGetRequestBuilder(MessageTemplateType messageType)
			: this()
		{
			this.MessageType = messageType;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("messageType"))
				kparams.AddIfNotNull("messageType", MessageType);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(JToken result)
		{
			return ObjectFactory.Create<MessageTemplate>(result);
		}
	}

// BEO-9522 csharp2 before comment
// BEO-9522 csharp2 before comment
	public class MessageTemplateUpdateRequestBuilder : RequestBuilder<MessageTemplate>
	{
		#region Constants
		public const string MESSAGE_TYPE = "messageType";
		public const string TEMPLATE = "template";
		#endregion

		public MessageTemplateType MessageType { get; set; }
		public MessageTemplate Template { get; set; }

		public MessageTemplateUpdateRequestBuilder()
			: base("messagetemplate", "update")
		{
		}

		public MessageTemplateUpdateRequestBuilder(MessageTemplateType messageType, MessageTemplate template)
			: this()
		{
			this.MessageType = messageType;
			this.Template = template;
		}

		public override Params getParameters(bool includeServiceAndAction)
		{
			Params kparams = base.getParameters(includeServiceAndAction);
			if (!isMapped("messageType"))
				kparams.AddIfNotNull("messageType", MessageType);
			if (!isMapped("template"))
				kparams.AddIfNotNull("template", Template);
			return kparams;
		}

		public override Files getFiles()
		{
			Files kfiles = base.getFiles();
			return kfiles;
		}

		public override object Deserialize(JToken result)
		{
			return ObjectFactory.Create<MessageTemplate>(result);
		}
	}


	public class MessageTemplateService
	{
		private MessageTemplateService()
		{
		}
// BEO-9522 csharp2 writeAction
// BEO-9522 csharp2 before comment

		public static MessageTemplateGetRequestBuilder Get(MessageTemplateType messageType)
		{
			return new MessageTemplateGetRequestBuilder(messageType);
		}
// BEO-9522 csharp2 writeAction
// BEO-9522 csharp2 before comment
// BEO-9522 csharp2 before comment

		public static MessageTemplateUpdateRequestBuilder Update(MessageTemplateType messageType, MessageTemplate template)
		{
			return new MessageTemplateUpdateRequestBuilder(messageType, template);
		}
	}
}
