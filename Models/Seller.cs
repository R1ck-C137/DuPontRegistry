﻿using Newtonsoft.Json.Linq;

namespace DuPontRegistry.Models
{
    public class Seller : User
    {
        public string Title { get; set; }
        public string Web { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public string Descr { get; set; }
        public string Metro { get; set; }
        public string State { get; set; }
        public JObject Contact { get; set; }
        public static string GetFields()
        {
            return UserFields + $@", ""{nameof(Title)}"", ""{nameof(Web)}"", ""{nameof(City)}"", ""{nameof(Logo)}"", ""{nameof(Descr)}"", ""{nameof(Metro)}"", ""{nameof(State)}"", ""{nameof(Contact)}""";
        }

        public static string GetValuesName()
        {
            return UserValuesName + $", @{nameof(Title)}, @{nameof(Web)}, @{nameof(City)}, @{nameof(Logo)}, @{nameof(Descr)}, @{nameof(Metro)}, @{nameof(State)}, @{nameof(Contact)}";
        }

        public override string ToString()
        {
            return UserToString + $@", {nameof(Title)}:""{Title}"", {nameof(Web)}:""{Web}"", {nameof(City)}:""{City}"", {nameof(Logo)}:""{Logo}"", {nameof(Descr)}:""{Metro}"", {nameof(State)}:""{State}"", {nameof(Contact)}:""{Contact}""";
        }
    }
}
