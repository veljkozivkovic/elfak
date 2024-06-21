import { Text, Card } from "@mantine/core";
import classes from "./OrganizerPage/OrganizerPage.module.css";

export interface StatsCardProps {
  title: string;
  current: number;
}

export function StatsCard(props: StatsCardProps) {
  return (
    <Card
      className={classes.statisticsCard}
      withBorder
      radius="md"
      padding="xl"
      bg="var(--mantine-color-body)"
    >
      <Text fz="xs" tt="uppercase" fw={700} c="dimmed" ta="center">
        {props.title}
      </Text>
      <Text fz="lg" fw={500} ta="center">
        {`${props.current}`}
      </Text>
    </Card>
  );
}
