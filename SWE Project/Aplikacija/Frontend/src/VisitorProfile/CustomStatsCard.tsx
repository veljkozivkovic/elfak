import { Text, Progress, Card } from "@mantine/core";
import classes from "./UserProfile.module.css";

export interface StatsCardProps {
  title: string;
  level: string;
  current: number;
  nextStage: number;
  dash: boolean;
}

export function CustomStatsCard(props: StatsCardProps) {
  const isLastStage = props.nextStage === -1;

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
        {props.dash ? " - " : ""}
        {props.level}
      </Text>
      <Text fz="lg" fw={500} ta="center">
        {isLastStage ? `${props.current}` : `${props.current} / ${props.nextStage}`}
      </Text>
      <Progress
        value={isLastStage ? 100 : (props.current / props.nextStage) * 100}
        mt="md"
        size="lg"
        radius="xl"
      />
    </Card>
  );
}
