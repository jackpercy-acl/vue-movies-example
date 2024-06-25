<script setup lang="ts">
import { useRouter } from 'vue-router';
import type { Movie } from '@/client';
import StarInput from '@/components/StarInput.vue';

const props = defineProps<{
  movies: Movie[];
}>();

const router = useRouter();

function openMovie(movieId: string) {
  router.push({
    name: 'movie',
    params: {
      id: movieId,
    },
  });
}
</script>

<template>
  <table>
    <thead>
      <tr>
        <th>Title</th>
        <th>Year</th>
        <th>Genres</th>
        <th>Rating</th>
      </tr>
    </thead>

    <tbody>
      <tr v-for="movie in props.movies" :key="movie.id" @click="openMovie(movie.id!)">
        <td>{{ movie.title }}</td>
        <td>{{ movie.year }}</td>
        <td>{{ movie.genres?.join(', ') }}</td>
        <td><StarInput v-model="movie.rating" /> </td>
      </tr>
    </tbody>
  </table>
</template>

<style scoped>
table {
  width: 100%;
  text-align: center;

}

th {
  font-weight: 700;
}
</style>
