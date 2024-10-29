<template>
  <div>
    <h2>{{ title }} value</h2>
    <input
      type="text"
      v-model="model"
      :placeholder="`Write ${title ?? 'value'} ${
        title.toLowerCase() == 'id'
          ? 'to search entity'
          : 'of Transaction Entity'
      }...`"
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
