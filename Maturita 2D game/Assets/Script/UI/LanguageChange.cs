using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageChange : MonoBehaviour
{
    public void SetLocale(int localeId)
    {
        Locale locale = LocalizationSettings.AvailableLocales.Locales[localeId];
        LocalizationSettings.SelectedLocale = locale;
    }
}
