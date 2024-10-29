<template>
  <div>
    <h2>{{ title }}</h2>
    <form>
      <div class="options">
        <div>
          <input
            :id="`${inputId}-default`"
            type="radio"
            :name="inputName"
            value=""
            v-model="model"
            checked
          />
          <label :for="`${inputId}-default`">Default</label>
        </div>
        <div v-for="(option, index) in options">
          <input
            :key="index"
            :id="`${inputId}-${option.toLowerCase()}`"
            type="radio"
            :name="inputName"
            :value="option.toLowerCase()"
            v-model="model"
          />
          <label :for="`${inputId}-${option.toLowerCase()}`">{{
            option
          }}</label>
        </div>
      </div>
    </form>
  </div>
</template>

<script setup lang="ts">
interface Props {
  title: string;
  options: string[];
}

const props = defineProps<Props>();
const model = defineModel();

const inputId = props.title.toLowerCase().replace(/ /g, '_');
const inputName =
  props.title[0].toLowerCase() +
  props.title.slice(1, props.title.length).replace(/ /g, '');
</script>

<style scoped>
.options {
  line-height: 1.5;
}
</style>
