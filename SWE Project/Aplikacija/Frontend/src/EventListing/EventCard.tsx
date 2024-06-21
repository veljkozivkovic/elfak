import { Card, Image, Text, Button, Group } from "@mantine/core";
import { EventCardProps } from "./interfaces";
import { IconCalendar, IconFlame, IconMapPin } from "@tabler/icons-react";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { setEvent } from "../store/features/selectedEvent";
import { useTranslation } from "react-i18next";

export default function EventCard(props: EventCardProps) {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { t } = useTranslation();

  return (
    <Card shadow="sm" padding="lg" radius="lg" withBorder w="20%" miw={300}>
      <Card.Section>
        <Image
          src={`data:image/jpeg;base64,${props.event.img}`}
          height={160}
          alt={`Couldn't load ${props.event.title} image`}
          fit="cover"
        />
      </Card.Section>

      <Group justify="space-between" mt="md" mb="lg">
        <Text fw={500}>{props.event.title}</Text>
      </Group>

      <Group mb="md">
        <IconMapPin />
        <Text fw={500}>{props.event.location}</Text>
      </Group>

      <Group mb="md">
        <IconCalendar />
        <Text fw={500}>{props.event.date}</Text>
      </Group>

      <Button
        variant="outline"
        color="gray"
        size="md"
        fullWidth
        mt="md"
        radius="md"
        onClick={(e) => {
          e.stopPropagation();
          dispatch(
            setEvent({
              ...props.event,
            })
          );
          navigate(`/eventinfo`);
        }}
      >
        {t("ReserveSeats")}{" "}
        <IconFlame color="var(--mantine-color-red-filled)" stroke={2.5} />
      </Button>
    </Card>
  );
}
