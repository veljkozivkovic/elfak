import { Text, Avatar, Group } from "@mantine/core";
import { Review } from "../interfaces";

export interface CommentProps {
  review: Review;
}

export function Comment(props: CommentProps) {
  return (
      <div style={{width: "100%"}}>
      <Group>
        <Avatar
          src={props.review.avatar}
          alt="User avatar"
          radius="xl"
        />
        <div>
          <Text size="sm">{props.review.name} - {props.review.rating}/10</Text>
          <Text size="xs" c="dimmed">
            {props.review.time}
          </Text>
        </div>
      </Group>
      <Text pl={54} pt="sm" size="sm">
        {props.review.comment}
      </Text>
    </div>
  );
}
