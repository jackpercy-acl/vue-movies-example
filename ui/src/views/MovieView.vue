<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import { type Movie, getApiMoviesById, putApiMoviesById } from '@/client';

const route = useRoute();

const movieId = computed(() => {
  return route.params.id as string;
});

const loading = ref(false);

const movie = ref<Movie | null>(null);

onMounted(async () => {
  await loadMovie();
});

async function loadMovie() {
  loading.value = true;
  movie.value = await getApiMoviesById({ id: movieId.value });
  loading.value = false;
}

async function saveMovie() {
  loading.value = true;
  await putApiMoviesById({
    id: movieId.value,
    requestBody: movie.value!,
  });

  loadMovie();

  loading.value = false;
}
</script>

<template>
  <h1>I'ma movie!</h1>
  <div v-if="movie && !loading">
    <label>Title</label>
    <input v-model="movie.title">
  </div>
  <button @click="saveMovie">
    Save
  </button>
</template>
