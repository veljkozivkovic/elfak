import { useState, useEffect } from "react";
import { UnstyledButton, Menu, Image, Group } from "@mantine/core";
import { IconChevronDown } from "@tabler/icons-react";
import english from "../../assets/english.png";
import serbian from "../../assets/serbian.png";
import classes from "./LanguagePicker.module.css";
import { useTranslation } from "react-i18next";

const data = [
  { label: "en", image: english },
  { label: "sr", image: serbian },
];

export function LanguagePicker() {
  const { i18n } = useTranslation();

  const getInitialLanguage = () => {
    const savedLanguage = localStorage.getItem("i18nextLng");
    return data.find((item) => item.label === savedLanguage) || data[0];
  };

  const [selected, setSelected] = useState(getInitialLanguage());
  const [opened, setOpened] = useState(false);

  useEffect(() => {
    if (selected.label !== i18n.language) {
      i18n.changeLanguage(selected.label);
    }
  }, [selected, i18n]);

  const items = data.map((item) => (
    <Menu.Item
      leftSection={<Image src={item.image} width={18} height={18} />}
      onClick={() => {
        setSelected(item);
        changeLanguage(item.label);
      }}
      key={item.label}
    >
      {item.label}
    </Menu.Item>
  ));

  const changeLanguage = (lng: string) => {
    i18n.changeLanguage(lng);
    localStorage.setItem("i18nextLng", lng);
  };

  return (
    <Menu
      onOpen={() => setOpened(true)}
      onClose={() => setOpened(false)}
      radius="md"
      width="target"
      withinPortal
    >
      <Menu.Target>
        <UnstyledButton
          className={classes.control}
          data-expanded={opened || undefined}
          c="dimmed"
        >
          <Group gap="xs">
            <Image src={selected.image} width={22} height={22} />
            <span className={classes.label}>{selected.label}</span>
          </Group>
          <IconChevronDown size="1rem" className={classes.icon} stroke={1.5} />
        </UnstyledButton>
      </Menu.Target>
      <Menu.Dropdown>{items}</Menu.Dropdown>
    </Menu>
  );
}
