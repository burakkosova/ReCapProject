﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araç silindi.";
        public static string CarUpdated= "Araç güncellendi.";
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi";
        public static string InvalidCarName = "Araba ismi en az 2 karakterden oluşmalıdır.";
        public static string InvalidDailyPrice = "Arabanın günlük fiyatı 0'dan büyük olmalıdır.";
        public static string CarNotFound = "Araç bulunamadı.";
        public static string BrandNotFound = "Marka bulunamadı.";
        public static string ColorNotFound = "Renk bulunamadı.";
        public static string BrandAlreadyExists = "Marka veritabanında zaten var!";
        public static string ColorAlreadyExists = "Renk veritabanında zaten var!";
    }
}