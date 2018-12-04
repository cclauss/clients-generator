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
// Copyright (C) 2006-2018  Kaltura Inc.
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
using Kaltura.Enums;
using Kaltura.Request;

namespace Kaltura.Types
{
	public class CountryFilter : Filter
	{
		#region Constants
		public const string ID_IN = "idIn";
		public const string IP_EQUAL = "ipEqual";
		public const string IP_EQUAL_CURRENT = "ipEqualCurrent";
		public new const string ORDER_BY = "orderBy";
		#endregion

		#region Private Fields
		private string _IdIn = null;
		private string _IpEqual = null;
		private bool? _IpEqualCurrent = null;
		private CountryOrderBy _OrderBy = null;
		#endregion

		#region Properties
		public string IdIn
		{
			get { return _IdIn; }
			set 
			{ 
				_IdIn = value;
				OnPropertyChanged("IdIn");
			}
		}
		public string IpEqual
		{
			get { return _IpEqual; }
			set 
			{ 
				_IpEqual = value;
				OnPropertyChanged("IpEqual");
			}
		}
		public bool? IpEqualCurrent
		{
			get { return _IpEqualCurrent; }
			set 
			{ 
				_IpEqualCurrent = value;
				OnPropertyChanged("IpEqualCurrent");
			}
		}
		public new CountryOrderBy OrderBy
		{
			get { return _OrderBy; }
			set 
			{ 
				_OrderBy = value;
				OnPropertyChanged("OrderBy");
			}
		}
		#endregion

		#region CTor
		public CountryFilter()
		{
		}

		public CountryFilter(XmlElement node) : base(node)
		{
			foreach (XmlElement propertyNode in node.ChildNodes)
			{
				switch (propertyNode.Name)
				{
					case "idIn":
						this._IdIn = propertyNode.InnerText;
						continue;
					case "ipEqual":
						this._IpEqual = propertyNode.InnerText;
						continue;
					case "ipEqualCurrent":
						this._IpEqualCurrent = ParseBool(propertyNode.InnerText);
						continue;
					case "orderBy":
						this._OrderBy = (CountryOrderBy)StringEnum.Parse(typeof(CountryOrderBy), propertyNode.InnerText);
						continue;
				}
			}
		}

		public CountryFilter(IDictionary<string,object> data) : base(data)
		{
			    this._IdIn = data.TryGetValueSafe<string>("idIn");
			    this._IpEqual = data.TryGetValueSafe<string>("ipEqual");
			    this._IpEqualCurrent = data.TryGetValueSafe<bool>("ipEqualCurrent");
			    this._OrderBy = (CountryOrderBy)StringEnum.Parse(typeof(CountryOrderBy), data.TryGetValueSafe<string>("orderBy"));
		}
		#endregion

		#region Methods
		public override Params ToParams(bool includeObjectType = true)
		{
			Params kparams = base.ToParams(includeObjectType);
			if (includeObjectType)
				kparams.AddReplace("objectType", "KalturaCountryFilter");
			kparams.AddIfNotNull("idIn", this._IdIn);
			kparams.AddIfNotNull("ipEqual", this._IpEqual);
			kparams.AddIfNotNull("ipEqualCurrent", this._IpEqualCurrent);
			kparams.AddIfNotNull("orderBy", this._OrderBy);
			return kparams;
		}
		protected override string getPropertyName(string apiName)
		{
			switch(apiName)
			{
				case ID_IN:
					return "IdIn";
				case IP_EQUAL:
					return "IpEqual";
				case IP_EQUAL_CURRENT:
					return "IpEqualCurrent";
				case ORDER_BY:
					return "OrderBy";
				default:
					return base.getPropertyName(apiName);
			}
		}
		#endregion
	}
}

