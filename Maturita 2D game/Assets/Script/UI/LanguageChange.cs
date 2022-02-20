using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
public class LanguageChange : MonoBehaviour
{
    public static LanguageChange instance;
    private void Start()
    {
        instance = this;

    }

    public void SetLocale(int localeId)
    {
        LocalizationSettings.InitializationOperation.WaitForCompletion();
        Locale locale = LocalizationSettings.AvailableLocales.Locales[localeId];
        LocalizationSettings.SelectedLocale = locale;
    }
}
