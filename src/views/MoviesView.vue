<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { type Movie, getApiMovies } from '@/client';
import MoviesTable from '@/components/MoviesTable.vue';
import MoviesGrid from '@/components/MoviesGrid.vue';

const loading = ref(false);
const movies = ref<Movie[]>([]);
const viewMode = ref<'table' | 'grid'>('table');

function switchMode() {
  if (viewMode.value === 'grid') {
    viewMode.value = 'table';
  }
  else {
    viewMode.value = 'grid';
  }
}

onMounted(async () => {
  loading.value = true;
  movies.value = await getApiMovies();
  loading.value = false;
});
</script>

<template>
  <main v-if="loading">
    <h1>Loading...</h1>
  </main>
  <main v-else>
    <button @click="switchMode">
      Show as {{ viewMode === 'table' ? 'Grid' : 'Table ' }}
    </button>
    <MoviesTable v-if="viewMode === 'table'" :movies="movies" />
    <MoviesGrid v-else-if="viewMode === 'grid'" :movies="movies" />
  </main>
</template>
