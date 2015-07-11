//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

#include "particleEmitter.h"
#include "console/consoleTypes.h"
#include "core/stream/bitStream.h"

IMPLEMENT_ABSTRACT_CONOBJECT(ParticleEmitterData);

static const float sgDefaultEjectionOffset = 0.f;
static const float sgDefaultSpinSpeed = 0.f;
static const float sgDefaultSpinSpeedVariance = 0.f;
static const float sgDefaultConstantAcceleration = 0.f;

ParticleEmitterData::ParticleEmitterData()
{
   mEjectionVelocity = 2.0f;
   mVelocityVariance = 1.0f;
   mEjectionOffset = sgDefaultEjectionOffset;
   mEjectionOffsetVariance = 0.0f;

   mSpinSpeed = sgDefaultSpinSpeed;
   mSpinSpeedVariance = sgDefaultSpinSpeedVariance;

   mInheritedVelFactor = 0.0f;
   mConstantAcceleration = sgDefaultConstantAcceleration;
}

void ParticleEmitterData::initPersistFields()
{
   addGroup("ParticleEmitterData");

   addField("EjectionVelocity", TypeF32, Offset(mEjectionVelocity, ParticleEmitterData),
      "Particle ejection velocity.");

   addField("VelocityVariance", TypeF32, Offset(mVelocityVariance, ParticleEmitterData),
      "Variance for ejection velocity, from 0 - ejectionVelocity.");

   addField("EjectionOffset", TypeF32, Offset(mEjectionOffset, ParticleEmitterData),
      "Distance along ejection Z axis from which to eject particles.");

   addField("EjectionOffsetVariance", TypeF32, Offset(mEjectionOffsetVariance, ParticleEmitterData),
      "Distance Padding along ejection Z axis from which to eject particles.");

   addField("SpinSpeed", TypeF32, Offset(mSpinSpeed, ParticleEmitterData),
      "Speed at which to spin the particle");

   addField("SpinSpeedVariance", TypeF32, Offset(mSpinSpeedVariance, ParticleEmitterData),
      "Variance for the angular velocity of particles, from 0 - 1000.");

   addField("InheritedVelFactor", TypeF32, Offset(mInheritedVelFactor, ParticleEmitterData),
      "Amount of emitter velocity to add to particle initial velocity.");

   addField("ConstantAcceleration", TypeF32, Offset(mConstantAcceleration, ParticleEmitterData),
      "Constant acceleration to apply to this particle.");

   endGroup("ParticleEmitterData");

   Parent::initPersistFields();
}

void ParticleEmitterData::packData(BitStream* stream)
{
   Parent::packData(stream);

   stream->writeInt((S32)(mEjectionVelocity * 100), 16);
   stream->writeInt((S32)(mVelocityVariance * 100), 14);
   if (stream->writeFlag(mEjectionOffset != sgDefaultEjectionOffset))
      stream->writeInt((S32)(mEjectionOffset * 100), 16);
   if (stream->writeFlag(mEjectionOffsetVariance != 0.0f))
      stream->writeInt((S32)(mEjectionOffsetVariance * 100), 16);

   if (stream->writeFlag(mSpinSpeed != sgDefaultSpinSpeed))
      stream->writeInt((S32)(mSpinSpeed * 100), 17);
   if (stream->writeFlag(mSpinSpeedVariance != sgDefaultSpinSpeedVariance))
      stream->writeInt((S32)(mSpinSpeedVariance * 100), 17);

   stream->writeFloat(mInheritedVelFactor, 9);
   if (stream->writeFlag(mConstantAcceleration != sgDefaultConstantAcceleration))
      stream->write(mConstantAcceleration);
}

void ParticleEmitterData::unpackData(BitStream* stream)
{
   Parent::unpackData(stream);

   mEjectionVelocity = stream->readInt(16) / 100.0f;
   mVelocityVariance = stream->readInt(14) / 100.0f;
   if (stream->readFlag())
      mEjectionOffset = stream->readInt(16) / 100.0f;
   else
      mEjectionOffset = sgDefaultEjectionOffset;
   if (stream->readFlag())
      mEjectionOffsetVariance = stream->readInt(16) / 100.0f;
   else
      mEjectionOffsetVariance = 0.0f;

   if (stream->readFlag())
      mSpinSpeed = stream->readInt(17) / 100.0f;
   if (stream->readFlag())
      mSpinSpeedVariance = stream->readInt(17) / 100.0f;

   mInheritedVelFactor = stream->readFloat(9);
   if (stream->readFlag())
      stream->read(&mConstantAcceleration);
}