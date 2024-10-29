<template>
  <div class="cards">
    <GetCard />
    <CreateCard />
    <UpdateCard />
    <RemoveCard />
  </div>
</template>

<script setup lang="ts">
import GetCard from './getCard/TransactionGetCard.vue';
import RemoveCard from './removeCard/TransactionRemoveCard.vue';
import CreateCard from './createCard/TransactionCreateCard.vue';
import UpdateCard from './updateCard/TransactionUpdateCard.vue';
</script>

<style lang="css" scoped>
.cards {
  display: grid;
  grid-template-columns: 1fr;
  row-gap: calc(1vh + 32px);
}
</style>
