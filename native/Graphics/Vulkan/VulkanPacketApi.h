#pragma once
#include "CelesteGraphicsPacket.h"
void VulkanBeginPacket(CelesteGraphicsDevice*, CelesteGraphicsPacket**);
void VulkanSubmitPacket(CelesteGraphicsPacket*, CelesteGraphicsSubmission**);
void VulkanReleasePacket(CelesteGraphicsPacket*) noexcept;
int32_t VulkanSubmissionCompletion(CelesteGraphicsSubmission*);
void VulkanWaitSubmission(CelesteGraphicsSubmission*);
void VulkanReleaseSubmission(CelesteGraphicsSubmission*) noexcept;
