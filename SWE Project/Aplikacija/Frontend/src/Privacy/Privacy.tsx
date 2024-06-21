import { Container, Flex, Paper, Text } from "@mantine/core";
import { HeaderMegaMenu } from "../HomePage/HeaderMegaMenu/HeaderMegaMenu";
import { Footer } from "../HomePage/Footer/Footer";
import EventBgImage from "../assets/event_listing_bg_op.png";
import { useTranslation } from "react-i18next";

export default function Privacy() {
  const { t } = useTranslation();

  return (
    <Flex
      direction="column"
      h="100%"
      styles={{
        root: {
          backgroundImage: `url(${EventBgImage})`,
          backgroundRepeat: "repeat",
        },
      }}
    >
      <HeaderMegaMenu />
      <Container size="sm">
        <Paper p="lg">
          <Text ta="center" size="lg" style={{ marginBottom: 20 }}>
            {t("Privacy")}
          </Text>
          <Text ta="justify">{t("Privacy_")}</Text>
          <Text ta="justify" style={{ marginBottom: 10, marginTop: 10 }}>
            <strong>{t("PrivacyTitle1")}</strong>
          </Text>
          <Text ta="justify">
            <strong>{t("PrivacyPersonalInfo")}</strong>{" "}
            {t("PrivacyPersonalInfoExpl")}
          </Text>
          <Text ta="justify">
            <strong>{t("PrivacyEventInfo")}</strong> {t("PrivacyEventInfoExpl")}
          </Text>
          <Text ta="justify">
            <strong>{t("PrivacyUsageData")}</strong> {t("PrivacyUsageDataExpl")}
          </Text>
          <Text ta="justify" style={{ marginBottom: 10, marginTop: 10 }}>
            <strong>{t("PrivacyHowWeUseInfo")}</strong>
          </Text>
          <Text ta="justify">
            <strong>{t("PrivacyProvideServices")}</strong>{" "}
            {t("PrivacyProvideServicesExpl")}
          </Text>
          <Text ta="justify">
            <strong>{t("PrivacyCommunication")}</strong>{" "}
            {t("PrivacyCommunicationExpl")}
          </Text>
          <Text ta="justify" style={{ marginBottom: 10, marginTop: 10 }}>
            <strong>{t("PrivacyDataSharingDisclosure")}</strong>
          </Text>
          <Text ta="justify">
            <strong>{t("PrivacyThirdPartyProviders")}</strong>{" "}
            {t("PrivacyThirdPartyProvidersExpl")}
          </Text>
          <Text ta="justify">
            <strong>{t("PrivacyLegalCompliance")}</strong>{" "}
            {t("PrivacyLegalComplianceExpl")}
          </Text>
          <Text ta="justify" style={{ marginBottom: 10, marginTop: 10 }}>
            <strong>{t("PrivacyDataSecurity")}</strong>
          </Text>
          <Text ta="justify">{t("PrivacyDataSecurityExpl")}</Text>
          <Text ta="justify" style={{ marginBottom: 10, marginTop: 10 }}>
            <strong>{t("PrivacyYourRights")}</strong>
          </Text>
          <Text ta="justify">
            <strong>{t("PrivacyAccessControl")}</strong>{" "}
            {t("PrivacyAccessControlExpl")}
          </Text>
          <Text ta="justify" style={{ marginBottom: 10, marginTop: 10 }}>
            <strong>{t("PrivacyChangesPolicy")}</strong>
          </Text>
          <Text ta="justify">{t("PrivacyChangesPolicyExpl")}</Text>
          <Text ta="justify" style={{ marginBottom: 10, marginTop: 10 }}>
            <strong>{t("PrivacyContactUs")}</strong>
          </Text>
          <Text ta="justify">{t("PrivacyContactUsExpl")}</Text>
          <Text ta="justify">{t("PrivacyAppliesTo")}</Text>
        </Paper>
      </Container>
      <Footer />
    </Flex>
  );
}
