<template>
  <div>
    <h2>Search by {{ title }}</h2>
    <input
      type="text"
      v-model="model"
      :placeholder="`Write ${title ?? 'request'} to search...`"
    />
  </div>
</template>

<script setup lang="ts">
interface Props {
  title: string;
}
const props = defineProps<Props>();
const model = defineModel();
</script>

<style scoped>
input {
  width: 100%;
}
</style>
