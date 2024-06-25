<script setup lang="ts">
import type { Movie } from '@/client';
import MoviesGridItem from '@/components/MoviesGridItem.vue';

const props = defineProps<{
  movies: Movie[];
}>();
</script>

<template>
  <div class="grid">
    <MoviesGridItem v-for="movie in props.movies" :key="movie.id" :movie="movie" />
  </div>
</template>

<style scoped>
.grid {
  display: flex;
  justify-content: space-between;
  gap: 40px
}

.movie {
  width: 250px;
  height: 400px;
}

img {
  width: 100%;
}
</style>
