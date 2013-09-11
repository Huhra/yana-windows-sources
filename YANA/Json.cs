/**
 * Yana for Windows par Valentin CARRUESCO aka idleman <idleman@idleman.fr> 
 * Licence Creative Commons -by -sa -nc
 * Classe de gestion du JSON : parsing et creation d'objets JSON
**/

using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;
namespace YANA
{
    public class Json
    {
        JObject mobjDatas;

        public Json()
        {
            this.mobjDatas = new JObject();
        }

        /// <summary>
        /// Constructeur prenant en paramêtre une chaine JSON textuelle ou un objet, ce parametre sera aussito convertis en objet JSON
        /// </summary>
        public Json(Object pobjJson)
        {
            try
            {
                if (pobjJson.GetType().FullName == "System.String")
                {

                    this.mobjDatas = JObject.Parse(pobjJson.ToString());
                }
                else
                {
                    this.mobjDatas = JObject.FromObject(pobjJson);
                }
            }
            catch (Exception e)
            {
                Function.error("Impossible de parser la réponse: " + e.Message);
            }
        }

        /// <summary>
        /// Récupère la valeur de la clé "key" sous forme de chaine
        /// </summary>
        public String fGetString(String pstrKey)
        {
            return (String)this.mobjDatas[pstrKey];
        }

        /// <summary>
        /// Récupère la valeur de la clé "key" sous forme d'entier
        /// </summary>
        public int fGetInt(String pstrKey)
        {
            JValue obj = (JValue)this.mobjDatas[pstrKey];
            return int.Parse((obj.ToString() == "" ? "0" : obj.ToString()));
        }


        public float fGetFloat(String pstrKey)
        {
            JValue obj = (JValue)this.mobjDatas[pstrKey];
            return (float)obj.ToObject<float>();
        }

        public bool fExist(String pstrKey)
        {
            return (this.mobjDatas[pstrKey] == null ? false : true);
        }

        public DateTime fGetDate(string pstrKey)
        {
            string date = (string)this.mobjDatas[pstrKey];
            if (date != "")
            {
                return Convert.ToDateTime(date);
            }
            else
            {
                return new DateTime();
            }
        }

        /// <summary>
        /// Récupère la valeur de la clé "key" sous forme d'un objet JSON
        /// </summary>
        public Json fGetJson(String pstrKey)
        {
            Json objJson = new Json();
            objJson.fSetData(JObject.Parse(this.mobjDatas[pstrKey].ToString()));
            return objJson;
        }

        /// <summary>
        /// Récupère la valeur de la clé "key" sous forme d'une liste
        /// </summary>
        public List<Json> fGetList(String pstrKey)
        {
            List<Json> lstReturnedList = new List<Json>();
            List<JToken> lstValues;
            try
            {
                lstValues = this.mobjDatas[pstrKey].ToList();
            }
            catch
            {
                lstValues = new List<JToken>();
            }
            foreach (JToken token in lstValues)
            {
                lstReturnedList.Add(new Json(token.ToString()));
            }
            return lstReturnedList;
        }




        /// <summary>
        /// Récupère la valeur de la clé "key" sous forme d'un booléen
        /// </summary>
        public bool fGetBool(String pstrKey)
        {
            return (this.fGetInt(pstrKey) == 1 ? true : false);
        }

        /// <summary>
        /// Définit la valeur "value" (String) pour la clé "key"
        /// </summary>
        public void fPut(String pstrKey, String pstrValue)
        {
            this.mobjDatas[pstrKey] = pstrValue;
        }

        /// <summary>
        /// Définit la valeur "value" (Bool) pour la clé "key"
        /// </summary>
        public void fPut(String pstrKey, Boolean pbolValue)
        {
            this.mobjDatas[pstrKey] = (pbolValue ? 1 : 0);
        }

        /// <summary>
        /// Définit la valeur "value" (Int) pour la clé "key"
        /// </summary>
        public void fPut(String pstrKey, int pintValue)
        {
            this.mobjDatas[pstrKey] = "" + pintValue;
        }

        /// <summary>
        /// Définit la valeur "value" (Json) pour la clé "key"
        /// </summary>
        public void fPut(String pstrKey, Json pobjValue)
        {
            this.mobjDatas[pstrKey] = pobjValue.ToString();
        }

        /// <summary>
        /// Définit la valeur "value" (List<Json>) pour la clé "key"
        /// </summary>
        public void fPut(String pstrKey, List<Json> pobjValue)
        {
            this.mobjDatas[pstrKey] = "[";
            foreach (Json pobjValueLine in pobjValue)
            {
                this.mobjDatas[pstrKey] += pobjValueLine.ToString() + ",";
            }
            String datas = this.mobjDatas[pstrKey].ToString();
            int datasLength = datas.Length;
            this.mobjDatas[pstrKey] = datas.Substring(0, datasLength - 1);
            this.mobjDatas[pstrKey] += "]";
        }

        /// <summary>
        /// Définit la valeur "value" (List<String>) pour la clé "key"
        /// </summary>
        public void fPut(String pstrKey, List<String> pobjValue)
        {
            this.mobjDatas[pstrKey] = JToken.FromObject(pobjValue);
        }


        /// <summary>
        /// Définit la valeur "value" (List<String>) pour la clé "key"
        /// </summary>
        public void fPut(String pstrKey, Object pobjValue)
        {
            this.mobjDatas[pstrKey] = JToken.FromObject(pobjValue);
        }

        /// <summary>
        /// Transforme l'objet JSON en chaine JSON (<i>ex: ({key1:'value1',key2:'value2'})</i>)
        /// </summary>
        public override String ToString()
        {
            return "(" + JsonConvert.SerializeObject(this.mobjDatas) + ")";
        }

        /// <summary>
        /// Méthode interne, definis l'objet JSON courant
        /// </summary>
        private void fSetData(JObject jObject)
        {
            this.mobjDatas = jObject;
        }

        public JObject getObjDatas()
        {
            return this.mobjDatas;
        }

        /// <summary>
        /// Récupère la valeur json correpondante a la clé "p" en échappant les guillemets
        /// pour les envois vers la base de données
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public String fGetSecureString(String p)
        {
            String value = this.fGetString(p);
            return (value != "" && value != null ? value.Replace("'", "''") : "");
        }

        public Object fGetDBIntValue(String p)
        {
            if (!Convert.IsDBNull(p))
            {
                String value = this.fGetString(p);
                return (value != "" && value != null ? value.Replace("'", "''") : "");
            }
            else
            {
                return DBNull.Value;
            }
        }

        public string fGetForeignKey(string p)
        {
            return (this.fGetString(p).Trim() == "" ? "NULL" : this.fGetString(p));
        }


    }
}