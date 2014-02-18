#include "px3ParticleEmitterNode.h"
#include "px3ParticleEmitter.h"

IMPLEMENT_CO_NETOBJECT_V1(Px3ParticleEmitterNode);

//-----------------------------------------------------------------------------
// ParticleEmitterNode
//-----------------------------------------------------------------------------
Px3ParticleEmitterNode::Px3ParticleEmitterNode()
{
   // Todo: ScopeAlways?
   mNetFlags.set(Ghostable);
   mTypeMask |= EnvironmentObjectType;

   mNodeTick = 0;
   timeSinceTick = 0;
}

//-----------------------------------------------------------------------------
// Destructor
//-----------------------------------------------------------------------------
Px3ParticleEmitterNode::~Px3ParticleEmitterNode()
{
   //
}

void Px3ParticleEmitterNode::initPersistFields()
{
   Parent::initPersistFields();
}

void Px3ParticleEmitterNode::setEmitterDataBlock(ParticleEmitterData* data)
{
   if (isServerObject())
   {
      setMaskBits(EmitterDBMask);
   }
   else
   {
      Px3ParticleEmitter* pEmitter = NULL;
      if (data)
      {
         // Create emitter with new datablock
         pEmitter = new Px3ParticleEmitter;
         pEmitter->onNewDataBlock(data, false);
         if (pEmitter->registerObject() == false)
         {
            Con::warnf(ConsoleLogEntry::General, "Could not register base emitter for particle of class: %s", data->getName() ? data->getName() : data->getIdString());
            delete pEmitter;
            return;
         }
      }

      // Replace emitter
      if (mEmitter)
         mEmitter->deleteWhenEmpty();

      mEmitter = pEmitter;
   }

   mEmitterDatablock = data;
}

void Px3ParticleEmitterNode::processTick(const Move* move)
{
   Parent::processTick(move);

   if (!mActive || mEmitter.isNull() || !mDataBlock)
      return;
   Point3F emitPoint, emitVelocity;
   Point3F emitAxis(0, 0, 1);
   getTransform().mulV(emitAxis);
   getTransform().getColumn(3, &emitPoint);
   emitVelocity = emitAxis * mVelocity;

   mEmitter->emitParticles(emitPoint, emitPoint,
      emitAxis,
      emitVelocity, (U32)(timeSinceTick * mDataBlock->timeMultiple));
   timeSinceTick = 0;
}

void Px3ParticleEmitterNode::advanceTime(F32 dt)
{
   GameBase::advanceTime(dt);

   U32 numMSToUpdate = (U32)(dt * 1000.0f);
   if (numMSToUpdate == 0) return;

   timeSinceTick += numMSToUpdate;
}