<script setup></script>

<template>
  <section>
    <div class="heroSection">
      <img src="/edvin.png" class="photo" alt="Edvin Nordin" />
      <div class="is-flex is-flex-direction-column">
        <h1 class="title">Edvin Nordin</h1>
        <h1 class="subtitle">Your next developer?</h1>
        <h1 class="subtitle">
          Site is currently under construction and is subject to change!
        </h1>
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
.heroSection {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding-left: 4px;
  @media (max-width: 768px) {
    flex-direction: column;
  }
}

.photo {
  max-width: 600px;
  @media (max-width: 768px) {
    display: none;
  }
}
</style>
