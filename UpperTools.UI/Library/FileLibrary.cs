using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System;
using UpperTools.UI.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;


namespace UpperTools.UI.Library
{
   public static class FileLibrary
   {
      public static List<Field> GetJsonFields(string Json)
      {

         object obj = JsonSerializer.Deserialize<object>(Json);
         Console.WriteLine("JsonString:" + Json);
         Console.WriteLine("Obj:" + obj.ToString());
         Console.WriteLine("ObjType:" + obj.GetType());

         var options = new JsonDocumentOptions
         {
            AllowTrailingCommas = true
         };

         var fields = new List<Field>();
         using (JsonDocument document = JsonDocument.Parse(Json, options))
         {
            fields = ReadProperties(document.RootElement).Distinct().Select(x=>new Field(){FieldName=x.TrimStart('.')}).ToList();
         }

         return fields;

      }

      public static List<string> ReadProperties(JsonElement json,string parent="")
      { 
         var result = new List<string>();

         if (json.ValueKind == JsonValueKind.Object)
         {
            foreach (JsonProperty element in json.EnumerateObject())
            {
               Console.WriteLine("JsonElement:" + element.Name);
               Console.WriteLine("JsonValueType:" + element.Value.GetType());
               Console.WriteLine("JsonType:" + element.GetType());
               if (element.Value.GetType() == typeof(System.Text.Json.JsonElement))
               {
                  result = result.Concat(ReadProperties(element.Value,parent+"."+element.Name)).ToList();
               }
            }
         }
         else if (json.ValueKind == JsonValueKind.Array)
         {
            foreach (JsonElement element in json.EnumerateArray())
            {               
               if (element.ValueKind == JsonValueKind.Object)
               {
                  result = result.Concat( ReadProperties(element,parent)).ToList();
               }
               else{
                  Console.WriteLine("JsonElementToString:" + element.ToString());
               }
            }
         }
         else {
            Console.WriteLine("JsonElementHasValue:" + json.ToString());
            Console.WriteLine("Parent:" + parent);
            result.Add(parent);            
         }

         return result;

      }

      public static async Task<string> GetStringFromStream(Stream stream)
      {
         using (var reader = new StreamReader(stream, Encoding.UTF8))
         {
            string value = await reader.ReadToEndAsync();
            return value;
            // Do something with the value
         }

      }


   }
}
