<script setup></script>
<template>
  <HeroSection />
  <ProjectsSection />
  <AboutSection />
</template>

<style lang="scss">
@use "../assets/css/variables.scss" as *;

.title {
  color: $titleColor;
  margin-left: 20px;
  margin-top: 20px;
  font-size: 2.5rem;
  padding-bottom: 10px;
}

.subtitle {
  color: $titleColor;
  margin-left: 20px;
  padding-bottom: 10px;
  font-size: 1.5rem;
}
</style>
