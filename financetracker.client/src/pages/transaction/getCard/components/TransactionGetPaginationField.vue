<template>
  <div>
    <h2>Write {{ title }} number</h2>
    <input
      type="number"
      v-model="model"
      :placeholder="`Write ${title ?? 'request'}...`"
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
