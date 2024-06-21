import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import HttpApi from "i18next-http-backend";

const savedLanguage = localStorage.getItem("i18nextLng") || "en";

i18n
  .use(HttpApi)
  .use(initReactI18next)
  .init({
    supportedLngs: ["en", "sr"],
    lng: savedLanguage,
    fallbackLng: "en",
    backend: {
      loadPath: "/locales/{{lng}}/translation.json",
    },
    react: {
      useSuspense: false,
    },
  });

export default i18n;
