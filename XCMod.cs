using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Json = MiniJSON;

namespace UnityEditor.XCodeEditor 
{
	public class XCMod 
	{
//		private string group;
//		private ArrayList patches;
//		private ArrayList libs;
//		private ArrayList frameworks;
//		private ArrayList headerpaths;
//		private ArrayList files;
//		private ArrayList folders;
//		private ArrayList excludes;
		private Dictionary<string, object> _datastore;
		private List<XCModFile> _libs;
		
		public string name { get; private set; }
		public string path { get; private set; }
		
		public string group {
			get {
				return (string)_datastore["group"];
			}
		}
		
		public List<object> patches {
			get {
				return (List<object>)_datastore["patches"];
			}
		}
		
		public List<XCModFile> libs {
			get {
				if( _libs == null ) {
					_libs = new List<XCModFile>( ((List<object>)_datastore["libs"]).Count );
					foreach( string fileRef in (List<object>)_datastore["libs"] ) {
						_libs.Add( new XCModFile( fileRef ) );
					}
				}
				return _libs;
			}
		}
		
		public List<object> frameworks {
			get {
				return (List<object>)_datastore["frameworks"];
			}
		}
		
		public List<object> headerpaths {
			get {
				return (List<object>)_datastore["headerpaths"];
			}
		}
		
		public List<object> files {
			get {
				return (List<object>)_datastore["files"];
			}
		}
		
		public List<object> folders {
			get {
				return (List<object>)_datastore["folders"];
			}
		}
		
		public List<object> excludes {
			get {
				return (List<object>)_datastore["excludes"];
			}
		}
		
		public XCMod( string filename )
		{	
			FileInfo projectFileInfo = new FileInfo( filename );
			if( !projectFileInfo.Exists ) {
				Debug.LogWarning( "File does not exist." );
			}
			
			name = System.IO.Path.GetFileNameWithoutExtension( filename );
			path = System.IO.Path.GetDirectoryName( filename );
			
			string contents = projectFileInfo.OpenText().ReadToEnd();
			_datastore = (Dictionary<string, object>)MiniJSON.Json.Deserialize( contents );
			
//			group = (string)_datastore["group"];
//			patches = (ArrayList)_datastore["patches"];
//			libs = (ArrayList)_datastore["libs"];
//			frameworks = (ArrayList)_datastore["frameworks"];
//			headerpaths = (ArrayList)_datastore["headerpaths"];
//			files = (ArrayList)_datastore["files"];
//			folders = (ArrayList)_datastore["folders"];
//			excludes = (ArrayList)_datastore["excludes"];
		}
		
			
//	"group": "GameCenter",
//	"patches": [],
//	"libs": [],
//	"frameworks": ["GameKit.framework"],
//	"headerpaths": ["Editor/iOS/GameCenter/**"],					
//	"files":   ["Editor/iOS/GameCenter/GameCenterBinding.m",
//				"Editor/iOS/GameCenter/GameCenterController.h",
//				"Editor/iOS/GameCenter/GameCenterController.mm",
//				"Editor/iOS/GameCenter/GameCenterManager.h",
//				"Editor/iOS/GameCenter/GameCenterManager.m"],
//	"folders": [],	
//	"excludes": ["^.*\\.meta$", "^.*\\.mdown^", "^.*\\.pdf$"]
		
	}
	
	public class XCModFile
	{
		public string filePath { get; private set; }
		public bool isWeak { get; private set; }
		
		public XCModFile( string inputString )
		{
			isWeak = false;
			
			if( inputString.Contains( ":" ) ) {
				string[] parts = inputString.Split( ':' );
				filePath = parts[0];
				isWeak = ( parts[1].CompareTo( "weak" ) == 0 );	
			}
			else {
				filePath = inputString;
			}
		}
	}
}