<script setup lang="ts">
const modelValue = defineModel<number>();
</script>

<template>
  <div class="stars">
    <input
      :value="modelValue"
      type="number"
      min="1"
      max="5"
      @input="modelValue = +$event.target.value"
    >
  </div>
</template>

<style>
.stars {
  display: flex;
  gap: 10px;
}

.star {
  background: gold;
  border-radius: 50px;
  height: 15px;
  width: 15px;
}
</style>
