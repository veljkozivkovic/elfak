import {
  Box,
  Progress,
  PasswordInput,
  Group,
  Text,
  Center,
} from "@mantine/core";
import { IconCheck, IconX } from "@tabler/icons-react";
import { useTranslation } from "react-i18next";

function PasswordRequirement({
  meets,
  label,
}: {
  meets: boolean;
  label: string;
}) {
  return (
    <Text component="div" c={meets ? "teal" : "red"} mt={5} size="sm">
      <Center inline>
        {meets ? (
          <IconCheck size="0.9rem" stroke={1.5} />
        ) : (
          <IconX size="0.9rem" stroke={1.5} />
        )}
        <Box ml={7}>{label}</Box>
      </Center>
    </Text>
  );
}

const requirements = [
  { re: /[0-9]/, label: "IncludesNumber" },
  { re: /[a-z]/, label: "IncludesLowercase" },
  { re: /[A-Z]/, label: "IncludesUppercase" },
  { re: /[$&+,:;=?@#|'<>.^*()%!-]/, label: "IncludesSpecial" },
];

function getStrength(password: string) {
  let multiplier = password.length > 5 ? 0 : 1;

  requirements.forEach((requirement) => {
    if (!requirement.re.test(password)) {
      multiplier += 1;
    }
  });

  return Math.max(100 - (100 / (requirements.length + 1)) * multiplier, 0);
}

export interface PasswordStrengthProps {
  label: string;
  placeholder: string;
  useFormProps: any;
  required: boolean;
}

export function PasswordStrength(props: PasswordStrengthProps) {
  const strength = getStrength(props.useFormProps.value);
  const { t } = useTranslation();

  const checks = requirements.map((requirement, index) => (
    <PasswordRequirement
      key={index}
      label={t(requirement.label)}
      meets={requirement.re.test(props.useFormProps.value)}
    />
  ));
  const bars = Array(4)
    .fill(0)
    .map((_, index) => (
      <Progress
        styles={{ section: { transitionDuration: "0ms" } }}
        value={
          props.useFormProps.value.length > 0 && index === 0
            ? 100
            : strength >= ((index + 1) / 4) * 100
            ? 100
            : 0
        }
        color={strength > 80 ? "teal" : strength > 50 ? "yellow" : "red"}
        key={index}
        size={4}
      />
    ));

  return (
    <div>
      <PasswordInput
        placeholder={props.placeholder}
        label={props.label}
        required={props.required}
        {...props.useFormProps}
      />

      <Group gap={5} grow mt="xs" mb="md">
        {bars}
      </Group>

      <PasswordRequirement
        label={t("AtLeast6")}
        meets={props.useFormProps.value.length > 5}
      />
      {checks}
    </div>
  );
}
