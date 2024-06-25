<script setup lang="ts">
// const props = defineProps<{
//   label: string;
// }>();

const emit = defineEmits<{
  click: [event: Event];
}>();
</script>

<template>
  <button @click="emit('click', $event)">
    <slot name="label" />
  </button>
</template>
