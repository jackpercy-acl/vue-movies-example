<script setup lang="ts">
import { ref } from 'vue';
import type { Movie } from '@/client';
import StarInput from '@/components/StarInput.vue';

const props = defineProps<{
  movie: Movie;
}>();
</script>

<template>
  <div class="movie">
    <img :src="props.movie.posterPath!">
    <div>{{ props.movie.title }}</div>
    <div>{{ props.movie.year }}</div>
    <div>{{ props.movie.genres?.join(', ') }}</div>
    <StarInput v-model="props.movie.rating" />
  </div>
</template>

<style scoped>
.movie {
  width: 250px;
  height: 400px;
}

img {
  width: 100%;
}
</style>
